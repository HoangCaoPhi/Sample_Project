
namespace MediatorPattern.Feature;
public class ServiceA : IRequest<string>
{
    public class ServiceAHandler : IRequestHandler<ServiceA, string>
    {
        public async Task<string> Handle(ServiceA request)
        {
            return "Kết quả xử lý sau khi nhận giá trị yêu cầu ServiceA";
        }
    }
}
