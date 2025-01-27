using Discount.gRPC.Data;
using Discount.gRPC.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Services;

public class DiscountService
    (DiscountContext discountContext, ILogger<DiscountService> logger)
    : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await discountContext
            .Coupones
            .FirstOrDefaultAsync(coupon => coupon.ProductName == request.ProductName);
        if (coupon is null)
            coupon = new Coupon { ProductName = "No Discount", Amount = 0, Description = "" };

        logger.LogInformation("Discount is retrieved for ProductName: {productName}, Amount: {amount}", coupon.ProductName, coupon.Amount);

        var couponModel = coupon.Adapt<CouponModel>();

        return couponModel;
    }
    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Adapt<Coupon>();
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object"));

        discountContext.Coupones.Add(coupon);
        await discountContext.SaveChangesAsync();

        logger.LogInformation("Discount created succesfully. ProductName: {productName}", coupon.ProductName);

        var couponModel = coupon.Adapt<CouponModel>();

        return couponModel;
    }


    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Adapt<Coupon>();
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object"));

        discountContext.Coupones.Update(coupon);
        await discountContext.SaveChangesAsync();

        logger.LogInformation("Discount updated succesfully. ProductName: {productName}", coupon.ProductName);

        var couponModel = coupon.Adapt<CouponModel>();

        return couponModel;
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var coupon = await discountContext
            .Coupones
            .FirstOrDefaultAsync(coupon => coupon.ProductName == request.ProductName);

        if (coupon is null)
            throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName: {request.ProductName} not found."));

        discountContext.Coupones.Remove(coupon);
        await discountContext.SaveChangesAsync();

        logger.LogInformation("Discount is succesfully deleted. ProductName: {productName}", coupon.ProductName);

        return new DeleteDiscountResponse { Success = true };
    }
}
