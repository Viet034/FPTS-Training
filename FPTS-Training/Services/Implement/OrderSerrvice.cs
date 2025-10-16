using Shared.Data;
using FPTS_Training.Mapper;
using Shared.Models;
using Shared.Models.DTO.RequestDTO.Order;
using Shared.Models.DTO.ResponseDTO;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using Shared.Models.DTO.RequestDTO.Order;
using Shared.Models.DTO.ResponseDTO;
using Shared.Ultility;
using System.Data;
using static Shared.Ultility.EntityStatus;

namespace FPTS_Training.Services.Implement;

public class OrderSerrvice : IOrderService
{
    private readonly FPTSTrainingDBContext _context;
    private readonly IOrderMapper _mapper;
    //private readonly IServiceScopeFactory serviceScopeFactory;

    public OrderSerrvice(FPTSTrainingDBContext context, IOrderMapper mapper)
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
            newCode = GenerateCode.GenerateOrderCode();
            _context.ChangeTracker.Clear();
            isExist = await _context.Orders.AnyAsync(p => p.Code == newCode);
        }
        while (isExist);

        return newCode;
    }

    public async Task<OrderResponseDTO> CreateOrderAsync(OrderCreateDTO create, long offsets, int partitions)
    {
        
        var parameter = new List<OracleParameter> 
        {
            new OracleParameter("v_id", OracleDbType.Varchar2, 50)
                {
                    Direction = ParameterDirection.Output,
                    Size = 50
                },
            new OracleParameter("v_buyerId", OracleDbType.Varchar2, create.BuyerId, ParameterDirection.Input),
            new OracleParameter("v_address", OracleDbType.Varchar2, create.Address, ParameterDirection.Input),
            new OracleParameter("v_status", OracleDbType.Int32, (int)create.Status, ParameterDirection.Input),
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
        
            
        await _context.Database.ExecuteSqlRawAsync(
            "BEGIN add_order(:v_id, :v_buyerId, :v_address, :v_status, :v_code, :v_name, :v_createDate, :v_createBy, :v_offset, :v_partition); END;",
            parameter.ToArray()
        );
        
        string newId = parameter[0].Value?.ToString();
        
        Console.WriteLine($"Id: {parameter[0].Value}, BuyerId: {parameter[1].Value}, Address: {parameter[2].Value}," +
            $"Status: {parameter[3].Value}, Code: {parameter[4].Value}, Name: {parameter[5].Value}, CreateDate: {parameter[6].Value}," +
            $"CreateBy: {parameter[7].Value}, Offset: {parameter[8].Value}, Partition: {parameter[9].Value}");

       // using var scop = 

        var entity = await _context.Orders.AsNoTracking().FirstOrDefaultAsync(c => c.Id == newId);
        //entity.Offsets = offsets;
        //entity.Partitions = partitions;
        entity.Status = OrderStatus.created;
        _context.Orders.Update(entity);
        _context.SaveChangesAsync();
        return _mapper.EntityToResponse(entity);
    }

    public async Task<OrderResponseDTO> FindOrderByIdAsync(int id)
    {
        var coId = await _context.Orders.FindAsync(id);
        if (coId == null)
        {
            throw new KeyNotFoundException($" Khong co Id {id} ton tai");
        }
        var response = _mapper.EntityToResponse(coId);
        return response;
    }

    public async Task<IEnumerable<OrderResponseDTO>> GetAllOrderAsync()
    {
        var co = await _context.Orders.OrderByDescending(x => x.CreateDate).ToListAsync();
        if (co == null) throw new Exception($"Khong co ban ghi nao");

        var response = _mapper.ListEntityToResponse(co);

        return response;
    }

    public async Task<bool> HardDeleteOrderAsync(OrderDeleteDTO delete)
    {
        var parameter = new List<OracleParameter>
        {
            new OracleParameter("v_id", OracleDbType.Varchar2, delete.Id, ParameterDirection.Input)

        };

        await _context.Database.ExecuteSqlRawAsync(
            "BEGIN delete_order(:v_id); END;",
            parameter.ToArray()
        );
        Console.WriteLine($" Id tim xoa{delete.Id}");
        return true;
    }

    public Task<IEnumerable<OrderResponseDTO>> SearchOrderByKeyAsync(string key)
    {
        throw new NotImplementedException();
    }

    public async Task<OrderResponseDTO> UpdateOrderAsync(OrderUpdateDTO update)
    {
        var parameters = new List<OracleParameter>
        {
            new OracleParameter("v_id", OracleDbType.Varchar2,update.Id, ParameterDirection.Input),
            new OracleParameter("v_address", OracleDbType.Varchar2,update.Address, ParameterDirection.Input),
            new OracleParameter("v_status", OracleDbType.Int32, (int)update.Status, ParameterDirection.Input),
            new OracleParameter("v_name", OracleDbType.Varchar2, update.Name, ParameterDirection.Input),
            new OracleParameter("v_updateDate", OracleDbType.Date, DateTime.UtcNow.AddHours(7), ParameterDirection.Input),
            new OracleParameter("v_updateBy", OracleDbType.Varchar2, update.Name, ParameterDirection.Input),

        };

        await _context.Database.ExecuteSqlRawAsync(
            "BEGIN update_order(:v_id, :v_address, :v_status, :v_name, :v_updateDate, :v_updateBy); END;",
            parameters.ToArray()
        );

        Console.WriteLine("Đã Execute xong");
        var entity = await _context.Orders.AsNoTracking().FirstOrDefaultAsync(c => c.Id == update.Id);
        if (entity == null)
        {
            throw new Exception("Null");
        }
        return _mapper.EntityToResponse(entity);
    }
}
