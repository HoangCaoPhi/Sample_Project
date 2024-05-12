namespace MediatorPattern.Feature;
public class ServiceB : IRequest<string>
{
    public class ServiceBHandler : IRequestHandler<ServiceB, string>
    {
        public async Task<string> Handle(ServiceB request)
        {
            return "Kết quả xử lý sau khi nhận giá trị yêu cầu ServiceB";
        }
    }
}