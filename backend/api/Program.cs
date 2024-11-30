using api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
//--- Huong Dan code run----
// add Migrations vào  VScode
// -> dotnet ef migrations add init 
// add tao cơ sở dữ liệu từ  Class vào SQL bằng code
// -> dotnet ef database update 


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// tạo day dẫn vào TV(Program)
builder.Services.AddDbContext<ApplicationDBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//Khi bạn gọi câu lệnh này, bạn đang đăng ký các bộ điều khiển (controllers) vào hệ thống định tuyến (routing) của ứng dụng, từ đó cho phép xử lý các yêu cầu HTTP và trả về phản hồi tương ứng
app.MapControllers();

app.Run();
