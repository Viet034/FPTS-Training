using FPTS_Training.Data;
using FPTS_Training.Mapper;
using FPTS_Training.Models.DTO.RequestDTO.OrderItem;
using FPTS_Training.Models.DTO.ResponseDTO;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace FPTS_Training.Services.Implement;

public class OrderItemService : IOrderItemService
{

    private readonly IOrderItemMapper _mapper;
    private readonly FPTSTrainingDBContext _context;

    public OrderItemService(IOrderItemMapper mapper, FPTSTrainingDBContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Task<string> CheckUniqueCodeAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<OrderItemResponseDTO> CreateOrderItemAsync(OrderItemCreateDTO create, long offsets, int partitions)
    {
        var parameter = new List<OracleParameter>
        {
            new OracleParameter("v_id", OracleDbType.Varchar2, 50)
            {
                Direction = ParameterDirection.Output,
                Size = 50
            },
            new OracleParameter("v_unit", OracleDbType.Varchar2, create.Units, ParameterDirection.Input),
            new OracleParameter("v_unitPrice", OracleDbType.Int32, create.UnitPrice, ParameterDirection.Input),
            new OracleParameter("v_productId", OracleDbType.Varchar2, create.ProductId, ParameterDirection.Input),
            new OracleParameter("v_orderId", OracleDbType.Varchar2, create.OrderId, ParameterDirection.Input),
            new OracleParameter("v_code", OracleDbType.Varchar2, create.Code, ParameterDirection.Input),
            new OracleParameter("v_name", OracleDbType.Varchar2, create.Name, ParameterDirection.Input),
            new OracleParameter("v_createDate", OracleDbType.Date, DateTime.UtcNow.AddHours(7), ParameterDirection.Input),
            new OracleParameter("v_createBy", OracleDbType.Varchar2, create.Name, ParameterDirection.Input),
            new OracleParameter("v_offset", OracleDbType.Int32, offsets, ParameterDirection.Input),
            new OracleParameter("v_partition", OracleDbType.Int32, partitions, ParameterDirection.Input),
        };

        await _context.Database.ExecuteSqlRawAsync(
            "BEGIN add_orderItem(:v_id, :v_unit, :v_unitPrice, :v_productId, :v_orderId, :v_code, :v_name, :v_createDate, :v_createBy, :v_offset, :v_partition); END;",
            parameter.ToArray()
        );

        string newId = parameter[0].Value?.ToString();
        Console.WriteLine($"Id: {parameter[0].Value}, unit: {parameter[1].Value}, unitPrice: {parameter[2].Value}," +
            $"productId: {parameter[3].Value}, orderId: {parameter[4]}, Code: {parameter[5].Value}, Name: {parameter[6].Value}, CreateDate: {parameter[7].Value}," +
            $"CreateBy: {parameter[8].Value}, Offset: {parameter[9].Value}, Partition: {parameter[10].Value}");

        var entity = await _context.OrderItems.AsNoTracking().FirstOrDefaultAsync(c => c.Id == newId);

        return _mapper.EntityToResponse(entity);
    }

    public Task<OrderItemResponseDTO> FindOrderItemByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<OrderItemResponseDTO>> GetAllOrderItemAsync()
    {
        var co = await _context.OrderItems.ToListAsync();
        if (co == null) throw new Exception($"Khong co ban ghi nao");

        var response = _mapper.ListEntityToResponse(co);

        return response;
    }

    public async Task<bool> HardDeleteOrderItemAsync(OrderItemDeleteDTO delete)
    {
        var parameter = new List<OracleParameter>
        {
            new OracleParameter("v_id", OracleDbType.Varchar2, delete.Id, ParameterDirection.Input)

        };

        await _context.Database.ExecuteSqlRawAsync(
            "BEGIN delete_orderItem(:v_id); END;",
            parameter.ToArray()
        );
        Console.WriteLine($" Id tim xoa{delete.Id}");
        return true;
    }

    public Task<IEnumerable<OrderItemResponseDTO>> SearchOrderItemByKeyAsync(string key)
    {
        throw new NotImplementedException();
    }

    public async Task<OrderItemResponseDTO> UpdateOrderItemAsync(OrderItemUpdateDTO update)
    {
        var parameters = new List<OracleParameter>
        {
            new OracleParameter("v_id", OracleDbType.Varchar2,update.Id, ParameterDirection.Input),
            new OracleParameter("v_unit", OracleDbType.Varchar2,update.Units, ParameterDirection.Input),
            new OracleParameter("v_unitPrice", OracleDbType.Int32, (int)update.UnitPrice, ParameterDirection.Input),
            new OracleParameter("v_productId", OracleDbType.Int32, update.ProductId, ParameterDirection.Input),
            new OracleParameter("v_name", OracleDbType.Varchar2, update.Name, ParameterDirection.Input),
            new OracleParameter("v_updateDate", OracleDbType.Date, DateTime.UtcNow.AddHours(7), ParameterDirection.Input),
            new OracleParameter("v_updateBy", OracleDbType.Varchar2, update.Name, ParameterDirection.Input),

        };

        await _context.Database.ExecuteSqlRawAsync(
            "BEGIN update_orderItem(:v_id, :v_unit, :v_unitPrice, :v_productId, :v_name, :v_updateDate, :v_updateBy); END;",
            parameters.ToArray()
        );

        Console.WriteLine("Đã Execute xong");
        var entity = await _context.OrderItems.AsNoTracking().FirstOrDefaultAsync(c => c.Id == update.Id);
        if (entity == null)
        {
            throw new Exception("Null");
        }
        return _mapper.EntityToResponse(entity);
    }
}
