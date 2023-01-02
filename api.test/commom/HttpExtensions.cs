using System.Text;

namespace api.test.commom;

public static class HttpExtensions
{
    public static async ValueTask Dump(this HttpResponseMessage res)
    {
        var sb = new StringBuilder();
        sb.AppendLine(res.ToString());
        sb.AppendLine(await res.Content.ReadAsStringAsync());
        await TestContext.Out.WriteLineAsync(sb.ToString());
    }
}