using Grpc.Core;
using System.Diagnostics;

namespace HomeGrpc.Services;

public class ListProcessorService : ListProcessor.ListProcessorBase
{
    private readonly ILogger<ListProcessorService> _logger;
    public ListProcessorService(ILogger<ListProcessorService> logger)
    {
        _logger = logger;
    }

    public override async Task<GetAllResponse> ListOfProcess(GetAllRequest request, ServerCallContext context)
    {
        var response = new GetAllResponse();
        Process[] processRunningAtSystem = Process.GetProcesses();

        foreach (var data in processRunningAtSystem)
        {
            response.AllProcess.Add(new SingleProcess
            {
                Id = data.Id,
                ProcessName = data.ProcessName
            });

        }
        return await Task.FromResult(response);
    }
}
