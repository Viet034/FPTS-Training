using FPTS_Training.Data;
using FPTS_Training.Mapper;
using FPTS_Training.Models;
using FPTS_Training.Models.DTO.RequestDTO.Product;
using FPTS_Training.Models.DTO.ResponseDTO;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using Shared.Ultility;
using System.Data;
using System.Reflection.Metadata;

namespace FPTS_Training.Services.Implement;

public class ProductService : IProductService
{
    private readonly FPTSTrainingDBContext _context;
    private readonly IProductMapper _mapper;

    public ProductService(FPTSTrainingDBContext context, IProductMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<string> CheckUniqueCodeAsync()
    {
        string newCode;
        bool isExist;

        do
        {
            newCode = GenerateCode.GenerateProductCode();
            _context.ChangeTracker.Clear();
            isExist = await _context.Products.AnyAsync(p => p.Code == newCode);
        }
        while (isExist);

        return newCode;
    }

    public async Task<ProductResponseDTO> CreateProductAsync(ProductCreateDTO create, long offsets, int partitions)
    {
        var parameters = new List<OracleParameter>
        {

            new OracleParameter("v_id", OracleDbType.Varchar2, 50)
                {
                    Direction = ParameterDirection.Output
                },
            new OracleParameter("v_status", OracleDbType.Int32, (int)create.Status, ParameterDirection.Input),
            new OracleParameter("v_code", OracleDbType.Varchar2, create.Code, ParameterDirection.Input),
            new OracleParameter("v_name", OracleDbType.Varchar2, create.Name, ParameterDirection.Input),
            new OracleParameter("v_createDate", OracleDbType.Date, DateTime.UtcNow.AddHours(7), ParameterDirection.Input),
            new OracleParameter("v_createBy", OracleDbType.Varchar2, create.Name, ParameterDirection.Input),
            new OracleParameter("v_offset", OracleDbType.Int32, offsets, ParameterDirection.Input),
            new OracleParameter("v_partition", OracleDbType.Int32, partitions, ParameterDirection.Input)
        };

        Console.WriteLine($"{parameters[0].Value}"); //có giá trị id
        
        //chạy qua mất giá trị Id
        await _context.Database.ExecuteSqlRawAsync(
            "BEGIN add_products(:v_id, :v_status, :v_code, :v_name, :v_createDate, :v_createBy, :v_offset, :v_partition); END;",
            parameters.ToArray()
        );

        Console.WriteLine($"parameter: {parameters[0].Value}");
        Console.WriteLine($"parameter: {parameters[2].Value}");

        // Lấy ID vừa insert từ OUT param (string)
        string newId = parameters[0].Value?.ToString();
        Console.WriteLine($"Id: {newId}, status: {parameters[0].Value}, code: {parameters[1].Value}, name: {parameters[2].Value}, creD: {parameters[3].Value}, creBy: {parameters[4].Value}, offset: {parameters[5].Value}, par: {parameters[6].Value}");

        // Query lại record theo Id
        var entity = await _context.Products.AsNoTracking().FirstOrDefaultAsync(c => c.Id == newId);
        

        return _mapper.EntityToResponse(entity);

    }

    public async Task<ProductResponseDTO> FindProductByIdAsync(string id)
    {
        var coId = await _context.Products.FindAsync(id);
        if (coId == null)
        {
            throw new KeyNotFoundException($" Khong co Id {id} ton tai");
        }
        var response = _mapper.EntityToResponse(coId);
        return response;

    }

    public async Task<IEnumerable<ProductResponseDTO>> GetAllProductAsync()
    {
        var co = await _context.Products.ToListAsync();
        if (co == null) throw new Exception($"Khong co ban ghi nao");

        var response = _mapper.ListEntityToResponse(co);

        return response;
    }

    public async Task<bool> HardDeleteProductAsync(ProductDeleteDTO delete)
    {
        var parameter = new List<OracleParameter> 
        {
            new OracleParameter("v_id", OracleDbType.Varchar2, delete.Id, ParameterDirection.Input)
        
        };

        await _context.Database.ExecuteSqlRawAsync(
            "BEGIN delete_products(:v_id); END;",
            parameter.ToArray()
        );
        Console.WriteLine($" Id tim xoa{delete.Id}");
        return true;
    }

    public Task<IEnumerable<ProductResponseDTO>> SearchProductByKeyAsync(string key)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductResponseDTO> UpdateProductAsync(ProductUpdateDTO update)
    {
        var parameters = new List<OracleParameter> 
        {
            new OracleParameter("v_id", OracleDbType.Varchar2,update.Id, ParameterDirection.Input),
            new OracleParameter("v_status", OracleDbType.Int32, (int)update.Status, ParameterDirection.Input),
            new OracleParameter("v_code", OracleDbType.Varchar2, update.Code, ParameterDirection.Input),
            new OracleParameter("v_name", OracleDbType.Varchar2, update.Name, ParameterDirection.Input),
            new OracleParameter("v_updateDate", OracleDbType.Date, DateTime.UtcNow.AddHours(7), ParameterDirection.Input),
            new OracleParameter("v_updateBy", OracleDbType.Varchar2, update.Name, ParameterDirection.Input),
   
        };

        await _context.Database.ExecuteSqlRawAsync(
            "BEGIN update_products(:v_id, :v_status, :v_code, :v_name, :v_updateDate, :v_updateBy); END;",
            parameters.ToArray()
        );

        Console.WriteLine("Đã Execute xong");
        var entity = await _context.Products.AsNoTracking().FirstOrDefaultAsync(c => c.Id == update.Id);
        if(entity == null)
        {
            throw new Exception("Null");
        }
        return _mapper.EntityToResponse(entity);

    }
}
