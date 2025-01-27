using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Data;

public static class Extentions
{
    public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
    {

        var scope = app.ApplicationServices.CreateScope();
        var dbContext = app.ApplicationServices.GetRequiredService<DiscountContext>();
        dbContext.Database.MigrateAsync();

        return app;
    }
}
