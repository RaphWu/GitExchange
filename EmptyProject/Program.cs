using ACadSharp;
using ACadSharp.IO;

class Program
{
    static void Main()
    {
        // 读取 DWG 文件
        CadDocument document = DwgReader.Read("你的图纸.dwg");

        // 统计实体数量
        Console.WriteLine($"文档包含{document.Entities.Count}个几何实体");

        // 遍历所有图层
        // 遍历文件夹中的所有 DWG 文件
        foreach (string file in Directory.GetFiles("图纸文件夹", "*.dwg"))
        {
            CadDocument doc = DwgReader.Read(file);

            // 查找所有圆形实体
            var circles = doc.Entities.OfType<Circle>();
            foreach (var circle in circles)
            {
                Console.WriteLine($"文件: {file}, 圆半径: {circle.Radius}");
            }
        }
    }

    // 自定义实体处理器示例
    public class CustomBlockTemplate : CadEntityTemplate<CustomBlock>
    {
// 优化大型文件处理
public void ProcessLargeCadFile(string filePath)
{
    using (var reader = new DwgReader(filePath))
    {
        // 启用流式处理模式，减少内存占用
        reader.Configuration.StreamingMode = true;

        // 跳过不需要的实体类型，提高处理速度
        reader.Configuration.EntitiesToSkip = new Type[]
        {
            typeof(Hatch),
            typeof(Mesh),
            typeof(ImageDefinition)
        };

        // 分批次处理实体
        CadDocument doc = reader.Read();

        // 按类型分组处理，提高效率
        var entitiesByType = doc.ModelSpace.Entities
                            .GroupBy(e => e.GetType())
                    .OrderBy(g => g.Count());

        foreach (var group in entitiesByType)
        {
            Console.WriteLine($"{group.Key.Name}: {group.Count()}个");
            ProcessEntityGroup(group.ToList());
        }
    }
}
    }

    // 使用带通知的读取器
    CadDocument doc = DwgReader.Read("图纸.dwg", OnNotification);
}