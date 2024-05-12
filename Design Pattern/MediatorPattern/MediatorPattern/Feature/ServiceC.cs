namespace MediatorPattern.Feature;
public class ServiceC : IRequest<string>
{
    public class ServiceCHandler : IRequestHandler<ServiceC, string>
    {
        public async Task<string> Handle(ServiceC request)
        {
            return "Kết quả xử lý sau khi nhận giá trị yêu cầu ServiceC";
        }
    }
}