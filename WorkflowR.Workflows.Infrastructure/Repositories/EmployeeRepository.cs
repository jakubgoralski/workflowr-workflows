using employees;
using WorkflowR.Workflows.Domain.Managing;

namespace WorkflowR.Workflows.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeesGrpcService.EmployeesGrpcServiceClient _grpcClient;

        public EmployeeRepository(EmployeesGrpcService.EmployeesGrpcServiceClient grpcClient)
        {
            _grpcClient = grpcClient;
        }
        public async Task<string> GetEmailOfEmployeeAsync(Guid employeeId)
        {
            try
            {
                GetEmailRequest getEmailRequest = new GetEmailRequest();
                getEmailRequest.Id = employeeId.ToString();

                GetEmailReply response = await _grpcClient.GetEmailAsync(getEmailRequest);
                return response.Email;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
