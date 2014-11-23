using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DocumentSystem
{
    static List<Document> documents = new List<Document>();

    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }
    
    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    private static void AddTextDocument(string[] attributes)
    {
        AddDocument(new DocText(), attributes);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        AddDocument(new DocPDF(), attributes);
    }

    private static void AddWordDocument(string[] attributes)
    {
        AddDocument(new DocWord(), attributes);
    }
  
    private static void AddExcelDocument(string[] attributes)
    {
        AddDocument(new DocExcel(), attributes);
    }
  
    private static void AddAudioDocument(string[] attributes)
    {
        AddDocument(new DocAudio(), attributes);
    }
  
    private static void AddVideoDocument(string[] attributes)
    {
        AddDocument(new DocVideo(), attributes);
    }
  
    private static void AddDocument(Document doc, string[] attributes)
    {
        foreach (var attr in attributes)
        {
            string[] coupleAttr = attr.Split('=');

            doc.LoadProperty(coupleAttr[0], coupleAttr[1]);
        }

        if (doc.Name != null)
        {
            documents.Add(doc);
            Console.WriteLine("Document added: {0}", doc.Name);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void ListDocuments()
    {
        if (documents.Count > 0)
        {
            foreach (var doc in documents)
            {
                if (doc is IEncryptable)
                {
                     if (((IEncryptable)doc).IsEncrypted)
                    {
                        Console.WriteLine("{0}[encrypted]", doc.GetType().Name);
                    }
                }
                else
                {
                    Console.WriteLine(doc.ToString());
                }
            }
        }
        else
        {
            Console.WriteLine("No documents found");
        }
    }

    private static void EncryptDocument(string name)
    {
        int filesFound = 0;

        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                filesFound++;
                if (doc is IEncryptable)
                {
                    ((IEncryptable)doc).Encrypt();
                    Console.WriteLine("Document encrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", doc.Name);
                }
            }
        }
        if (filesFound == 0)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void DecryptDocument(string name)
    {
        int filesFound = 0;

        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                filesFound++;
                if (doc is IEncryptable)
                {
                    ((IEncryptable)doc).Decrypt();
                    Console.WriteLine("Document Decrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", doc.Name);
                }
            }
        }
        if (filesFound == 0)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void EncryptAllDocuments()
    {
        int filesFound = 0;

        foreach (var doc in documents)
        {
            if (doc is IEncryptable)
            {
                filesFound++;
                ((IEncryptable)doc).Encrypt();
            }
        }

        if (filesFound == 0)
        {
            Console.WriteLine("No encryptable documents found");
        }
        else
        {
            Console.WriteLine("All documents encrypted");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        int filesFound = 0;

        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                filesFound++;
                if (doc is IEditable)
                {
                    ((IEditable)doc).ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: {0}", doc.Name);
                }
            }
        }
        if (filesFound == 0)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }
}
