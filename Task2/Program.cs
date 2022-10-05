using Task2.Infrastructure;

namespace Task2
{
    public class Program
    {

        //Задание 1
        //Создайте фильтр, который будет считать количество уникальных пользователей, выполнивших
        //запрос к веб приложению.Информацию о количестве пользователей фильтр должен
        //записывать в файл.

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(option =>
            {
                //option.Filters.Add<ProfileAttribute>();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
        }
    }
}