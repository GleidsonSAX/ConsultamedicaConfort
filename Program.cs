using ConsultamedicaConfort.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do EF Core
builder.Services.AddDbContext<ConsultamedicaConfortContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConsultamedicaConfortContext")
        ?? throw new InvalidOperationException("Connection string 'ConsultamedicaConfortContext' não encontrada.")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Pipeline HTTP padrão
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


