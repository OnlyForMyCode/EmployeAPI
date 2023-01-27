using AutoMapper;
using Employee.Business.Repositories.IRepositories;
using Employee.Data.Entities;
using Employee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace EmployeAPI.Endpoints
{
    public static class EmployeeEndpoints
    {
        public static void ConfigureEmployeeEndpoints(this WebApplication app)
        {
            app.MapGet("/api/employee", GetAllEmployee)
                .WithName("GetEmployees")
                .Produces<APIResponse>(200)
                .RequireAuthorization();
            //.RequireAuthorization("AdminOnly");

            app.MapGet("/api/employee/{id:int}", GetEmployee)
                .WithName("GetEmployee")
                .Produces<APIResponse>(200);

            app.MapPost("/api/employee", CreateEmployee)
                .WithName("CreateEmployee")
                .Accepts<EmployeeCreateDTO>("application/json")
                .Produces<APIResponse>(201)
                .Produces(400);

            app.MapPut("/api/employee", UpdateEmployee)
                .WithName("UpdateEmployee")
                .Accepts<EmployeeUpdateDTO>("application/json")
                .Produces<APIResponse>(200)
                .Produces(400);

            app.MapDelete("/api/employee/{id:int}", DeleteEmployee);
        }

        private async static Task<IResult> DeleteEmployee(IEmployeeRepository couponRepository, int id)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };

            EmployeeDTO couponFromStore = await couponRepository.GetAsync(id);
            if (couponFromStore != null)
            {
                await couponRepository.RemoveAsync(couponFromStore.Id);
                //await couponRepository.SaveAsync();
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.NoContent;
                return Results.Ok(response);
            }
            else
            {
                response.ErrorMessages.Add("Invalid Id");
                return Results.BadRequest(response);
            }
        }

        private async static Task<IResult> UpdateEmployee(
            IEmployeeRepository couponRepository,
            IMapper mapper,
            [FromBody] EmployeeUpdateDTO coupon_U_DTO)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };

            //await couponRepository.UpdateAsync(mapper.Map<Coupon>(coupon_U_DTO));
            await couponRepository.UpdateAsync(mapper.Map<EmployeeDTO>(coupon_U_DTO));
            //await couponRepository.SaveAsync();

            response.Result = mapper.Map<EmployeeDTO>(await couponRepository.GetAsync(coupon_U_DTO.Id));
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            return Results.Ok(response);
        }


        private async static Task<IResult> CreateEmployee(
            IEmployeeRepository couponRepository,
            IMapper mapper,
            [FromBody] EmployeeCreateDTO coupon_C_DTO)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };

            if (couponRepository.GetAsync(coupon_C_DTO.FirstName,coupon_C_DTO.LasttName,coupon_C_DTO.Created).GetAwaiter().GetResult() != null)
            {
                response.ErrorMessages.Add("Employee name already exists");
                return Results.BadRequest(response);
            }

            //Coupon coupon = mapper.Map<Coupon>(coupon_C_DTO);
            EmployeeDTO coupon = mapper.Map<EmployeeDTO>(coupon_C_DTO);
            await couponRepository.CreateAsync(coupon);
            //await couponRepository.SaveAsync();

            EmployeeDTO couponDTO = mapper.Map<EmployeeDTO>(coupon);
            response.Result = couponDTO;
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.Created;
            return Results.Ok(response);

            //return Results.CreatedAtRoute("GetCoupon",new { id=coupon.Id }, couponDTO);
            //return Results.Created($"/api/coupon/{coupon.Id}",coupon);
        }

        [Authorize]
        private async static Task<IResult> GetAllEmployee(
            IEmployeeRepository _couponRepo, ILogger<Program> _logger)
        {
            APIResponse response = new();
            _logger.Log(LogLevel.Information, "Getting all Employees");
            response.Result = await _couponRepo.GetAllAsync();
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            return Results.Ok(response);
        }

        private async static Task<IResult> GetEmployee(
            IEmployeeRepository _couponRepo, ILogger<Program> _logger, int id)
        {
            APIResponse response = new();
            response.Result = await _couponRepo.GetAsync(id);
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            return Results.Ok(response);
        }

    }
}
