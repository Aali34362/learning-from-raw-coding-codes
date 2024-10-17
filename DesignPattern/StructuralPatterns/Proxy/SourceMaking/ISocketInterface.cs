namespace Proxy.SourceMaking;

interface ISocketInterface
{
    string ReadLine();
    void WriteLine(string str);
    void Dispose();
}
