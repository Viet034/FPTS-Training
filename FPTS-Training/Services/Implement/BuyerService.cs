using Shared.Data;
using FPTS_Training.Mapper;
using Shared.Models;
using Shared.Models.DTO.RequestDTO.Buyer;
using Shared.Models.DTO.ResponseDTO;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using Shared.Ultility;
using System.Data;

namespace FPTS_Training.Services.Implement;

public class BuyerService : IBuyerService
{
    private readonly FPTSTrainingDBContext _context;
    private readonly IBuyerMapper _mapper;

    public BuyerService(FPTSTrainingDBContext context, IBuyerMapper mapper)
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
            newCode = GenerateCode.GenerateBuyerCode();
            _context.ChangeTracker.Clear();
            isExist = await _context.Buyers.AnyAsync(p => p.Code == newCode);
        }
        while (isExist);

        return newCode;
    }

    public async Task<BuyerResponseDTO> CreateBuyerAsync(BuyerCreateDTO create, long offsets, int partitions)
    {
        
        var parameter = new List<OracleParameter>
        {
             new OracleParameter("v_id", OracleDbType.Varchar2, 50)
                {
                    Direction = ParameterDirection.Output
                },
        
            
            new OracleParameter("v_payment", OracleDbType.Varchar2, create.PaymentMethod, ParameterDirection.Input),
            new OracleParameter("v_code", OracleDbType.Varchar2, create.Code, ParameterDirection.Input),
            new OracleParameter("v_name", OracleDbType.Varchar2, create.Name, ParameterDirection.Input),
            new OracleParameter("v_createDate", OracleDbType.Date, DateTime.UtcNow.AddHours(7), ParameterDirection.Input),
            new OracleParameter("v_createBy", OracleDbType.Varchar2, create.Name, ParameterDirection.Input),
            new OracleParameter("v_offset", OracleDbType.Int32, offsets, ParameterDirection.Input),
            new OracleParameter("v_partition", OracleDbType.Int32, partitions, ParameterDirection.Input)
        };
        //var idParam = new OracleParameter("v_id", OracleDbType.Varchar2, 50)
        //{
        //    Direction = ParameterDirection.Output
        //};
        //parameter.Add(idParam);
        
        var check = await _context.Database.ExecuteSqlRawAsync(
            "BEGIN add_buyer(:v_id, :v_payment, :v_code, :v_name, :v_createDate, :v_createBy, :v_offset, :v_partition); END;",
            parameter.ToArray()
        );
        
        string newId = parameter[0].Value?.ToString();
        Console.WriteLine($"Id: {newId}, payment: {parameter[1].Value}, code: {parameter[2].Value}, name: {parameter[3].Value},creDate: {parameter[4].Value} creBy: {parameter[5].Value}, offset: {parameter[6].Value}, par: {parameter[7].Value}");
        
        var entity = await _context.Buyers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == newId);
        //var entity = await _context.Buyers
        //    .FromSqlRaw("SELECT * FROM BUYERS WHERE ID = {0}", newId)
        //    .OrderBy(c => c.Code)
            
        //    .FirstOrDefaultAsync();

        return _mapper.EntityToResponse(entity);

    }

    public async Task<BuyerResponseDTO> FindBuyerByIdAsync(int id)
    {
        var coId = await _context.Buyers.FindAsync(id);
        if (coId == null)
        {
            throw new KeyNotFoundException($" Khong co Id {id} ton tai");
        }
        var response = _mapper.EntityToResponse(coId);
        return response;
    }

    public async Task<IEnumerable<BuyerResponseDTO>> GetAllBuyerAsync()
    {
        var co = await _context.Buyers.OrderByDescending(x => x.CreateDate).ToListAsync();
        if (co == null) throw new Exception($"Khong co ban ghi nao");

        var response = _mapper.ListEntityToResponse(co);

        return response;
    }

    public async Task<bool> HardDeleteBuyerAsync(BuyerDeleteDTO delete)
    {
        var parameter = new List<OracleParameter>
        {
            new OracleParameter("v_id", OracleDbType.Varchar2, delete.Id, ParameterDirection.Input)

        };

        await _context.Database.ExecuteSqlRawAsync(
            "BEGIN delete_buyer(:v_id); END;",
            parameter.ToArray()
        );
        Console.WriteLine($" Id tim xoa{delete.Id}");
        return true;
    }

    public Task<IEnumerable<BuyerResponseDTO>> SearchBuyerByKeyAsync(string key)
    {
        throw new NotImplementedException();
    }

    public async Task<BuyerResponseDTO> UpdateBuyerAsync( BuyerUpdateDTO update)
    {
        var parameters = new List<OracleParameter>
        {
            new OracleParameter("v_id", OracleDbType.Varchar2,update.Id, ParameterDirection.Input),
            new OracleParameter("v_payment", OracleDbType.Varchar2,update.PaymentMethod, ParameterDirection.Input),
            new OracleParameter("v_name", OracleDbType.Varchar2, update.Name, ParameterDirection.Input),
            new OracleParameter("v_updateDate", OracleDbType.Date, DateTime.UtcNow.AddHours(7), ParameterDirection.Input),
            new OracleParameter("v_updateBy", OracleDbType.Varchar2, update.Name, ParameterDirection.Input),

        };

        await _context.Database.ExecuteSqlRawAsync(
            "BEGIN update_buyer(:v_id, :v_payment, :v_name, :v_updateDate, :v_updateBy); END;",
            parameters.ToArray()
        );

        Console.WriteLine("Đã Execute xong");
        var entity = await _context.Buyers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == update.Id);
        if (entity == null)
        {
            throw new Exception("Null");
        }
        return _mapper.EntityToResponse(entity);
    }
}
