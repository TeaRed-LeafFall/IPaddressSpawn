namespace IPaddressSpawn;
public static class Program
{
    public static void Main()
    {
        Console.WriteLine("欢迎使用 IP address Spawn!");
        var startIp = InputIp("现在请输入开始的Ip地址(xxx.xxx.xxx.xxx):");
        var endIp = InputIp("现在请输入结束的Ip地址(xxx.xxx.xxx.xxx):");

        Console.Write("现在请输入最大的地址单项数据(数字):");
        var inputMaxInt = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        var ip1 = startIp[0];
        var ip2 = startIp[1];
        var ip3 = startIp[2];
        var ip4 = startIp[3];
        var count = 0;

        
        inputpath:
        // 获取用户输入的文件路径
        Console.WriteLine("请输入要保存的文件路径：");
        var filePath = Console.ReadLine();
        if (Path.Exists(filePath) || string.IsNullOrEmpty(filePath))
        {
            goto inputpath;
        }
        

        using (var writer = new StreamWriter(filePath))
        {
            Parallel.For(0, endIp[0] + 1, ip1 =>
            {
                for (var ip2 = ip1 == 0 ? 0 : 1; ip2 <= (ip1 == endIp[0] ? endIp[1] : inputMaxInt); ip2++)
                {
                    for (var ip3 = ip1 == 0 && ip2 == 0 ? 0 : 1; ip3 <= (ip1 == endIp[0] && ip2 == endIp[1] ? endIp[2] : inputMaxInt); ip3++)
                    {
                        for (var ip4 = ip1 == 0 && ip2 == 0 && ip3 == 0 ? 0 : 1; ip4 <= (ip1 == endIp[0] && ip2 == endIp[1] && ip3 == endIp[2] ? endIp[3] : inputMaxInt); ip4++)
                        {
                            var ipAddress = $"{ip1}.{ip2}.{ip3}.{ip4}";
                            count++;
                            var output = $"{ipAddress}\n";
                            Console.Write(count + " - " + output);
                            writer.Write(output);
                        }
                    }
                }
            });
        }

        Console.WriteLine("一共生成了 " + count + " 条数据!");

        Console.WriteLine("任务执行完成！按任意键退出");
        Console.ReadLine();
    }


    private static List<int> InputIp(string message)
    {
        inputIp:
        Console.Write(message);
        var input=Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("输入不合规");
            goto inputIp;
        }
        var inputStartIps = input.Split('.');
        var ipd = new List<int>();
        if (inputStartIps.Length != 4)
        {
            Console.WriteLine("输入不合规");
            goto inputIp;
        }
        else
        {
            foreach (var str in inputStartIps)
            {
                ipd.Add(int.Parse(str));
            }
        }
        return ipd;
    }
}