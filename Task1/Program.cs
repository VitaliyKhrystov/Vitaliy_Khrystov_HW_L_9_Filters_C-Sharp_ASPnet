using Task1.Infrastructure;

namespace Task1
{
    public class Program
    {

        //������� 1 (Additional Task)
        //�������� ��� ���������� � ������ ��������, ������� ����� ���������� � ���� ��� ������
        //�������� � ����� ��������� � ����.��� ���� ������ ����� ���� �������� � ������ ������
        //�������� ����������.

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Make Global Attribute
            builder.Services.AddControllersWithViews(option =>
            {
                option.Filters.Add<ProfileAttribute>();
            });

            

            var app = builder.Build();

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
        }
    }
}