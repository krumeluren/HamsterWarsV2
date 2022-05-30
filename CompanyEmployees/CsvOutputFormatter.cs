using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace HamsterWars;
public class CsvOutputFormatter<T> : TextOutputFormatter
{
    public CsvOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }

    protected override bool CanWriteType(Type? type)
    {
        //TODO: Add support for all types
        if (typeof(T).IsAssignableFrom(type) 
            || typeof(IEnumerable<T>).IsAssignableFrom(type))
        {
            return base.CanWriteType(type);
        }
        return false;
    }
    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var buffer = new StringBuilder();
        if (context.Object is IEnumerable<T>)
        {
            foreach (var company in (IEnumerable<T>)context.Object)
            {
                FormatCsv(buffer, company);
            }
        }
        else 
        {
            FormatCsv(buffer, (T)context.Object);
        }
        await response.WriteAsync(buffer.ToString());
    }
    
    private void FormatCsv(StringBuilder buffer, T entityDto)
    { 
        foreach (var property in entityDto.GetType().GetProperties())
        {          
            buffer.Append($"\"{property.GetValue(entityDto)}\",");        
        }
        buffer.AppendLine();
    }
}
