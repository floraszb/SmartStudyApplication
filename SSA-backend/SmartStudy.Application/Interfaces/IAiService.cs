using System.Threading.Tasks;

namespace SmartStudy.Application.Interfaces
{
    public interface IAiService
    {
        Task<string> GenerateTextAsync(string prompt);
    }
}