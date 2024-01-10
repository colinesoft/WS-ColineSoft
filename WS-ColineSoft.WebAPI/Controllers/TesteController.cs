using Microsoft.AspNetCore.Mvc;
using WS_ColineSoft.DAL.Context;
using System.Xml;

namespace WS_ColineSoft.WebAPI.Controllers
{
    public class TesteController : ControllerBase
    {
        private readonly ColineSoftContext _colineSoftContext;
        private readonly ILogger<TesteController> _logger;
        public TesteController(ColineSoftContext colineSoftContext, ILogger<TesteController> logger)
        {
            _colineSoftContext = colineSoftContext;
            _logger = logger;

        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            _logger.LogInformation("Information LOG");
            _logger.LogError("Error LOG");
            _logger.LogCritical("Critical LOG");
            _logger.LogDebug("Debugger LOG");
            _logger.LogTrace("Trace LOG");
            _logger.LogWarning("Warning LOG");
            //var v1 =_colineSoftContext.Usuarios;
            return Ok(_colineSoftContext.Teste);
        }

        [HttpGet("LerXML")]
        public IActionResult LerXML()
        {
            string arquivoLayout = ObterLocalGravacaoLogs();
            PrepararArquivoDeConfigracaoLog();
            var ativos = ObterStatusTiposLogs();
            SalvarLayoutConfiguracaoLog(ativos);
            SalvarLayoutConfiguracaoLog(ativos);

            string resultado = "";
            string caminhoArquivo = @"c:\temp\LogTelefonia.xml";
            if (!System.IO.File.Exists(caminhoArquivo))
                throw new FileNotFoundException("Arquivo XML não encontrado em " + caminhoArquivo);

            using (XmlTextReader xmlReader = new XmlTextReader(caminhoArquivo))
            {
                while (xmlReader.Read())
                {
                    switch (xmlReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            resultado += ("<" + xmlReader.Name + ">") + Environment.NewLine;
                            var v1 = xmlReader.GetAttribute("name");
                            break;
                        case XmlNodeType.Text:
                            var element = xmlReader.GetAttribute(0);
                            resultado += (xmlReader.Value) + Environment.NewLine;
                            break;
                        case XmlNodeType.EndElement:
                            resultado += ("</" + xmlReader.Name + ">") + Environment.NewLine;
                            break;
                    }
                }
            }
            return Ok(ativos);
        }

      
        private string ObterLocalGravacaoLogs()
        {
            string arquivoLayout = @"c:\temp\app_data\layout_LogTelefonia.xml";
            string resultado = "";

            if (!System.IO.File.Exists(arquivoLayout))
                throw new FileNotFoundException("O arquivo de configuração do LOG não foi encontrado: " + arquivoLayout);

            using (XmlTextReader xmlReader = new XmlTextReader(arquivoLayout))
            {
                while (xmlReader.Read())
                {
                    if(xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "storageLog")
                    {
                        resultado = xmlReader.GetAttribute("file") ?? "";
                        break;
                    }
                }
            }
            return resultado;
        }

        private Dictionary<string, bool> ObterStatusTiposLogs()
        {
            string arquivoLayout = @"c:\temp\app_data\layout_LogTelefonia.xml";
            Dictionary<string, bool> logs = new Dictionary<string, bool>();

            if (!System.IO.File.Exists(arquivoLayout))
                throw new FileNotFoundException("O arquivo de configuração do LOG não foi encontrado: " + arquivoLayout);

            using (XmlTextReader xmlReader = new XmlTextReader(arquivoLayout))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "activeLog")
                    {
                        //Encontrou o elemento de definição de LOG
                        string[]? possiveisLogs = xmlReader.GetAttribute("value")?.Split(',');
                        if(possiveisLogs != null)
                            foreach (var item in possiveisLogs)
                                logs.Add(item.Split('=')[0].Trim(), item.Split('=')[1].Trim() == "1");
                        break;
                    }
                }
            }
            return logs;
        }

        private void PrepararArquivoDeConfigracaoLog()
        {
            string destinoLog = ObterLocalGravacaoLogs();
            string arquivoLayout = @"c:\temp\app_data\layout_LogTelefonia.xml";
            string arquivoDestino = @"c:\temp\LogTelefonia.xml";

            try
            {
                //1 - Apaga arquivo de destino caso ele exista
                System.IO.File.Delete(arquivoDestino);
                //2 - Copia o arquivo de layout para o local correto
                System.IO.File.Copy(arquivoLayout, arquivoDestino);
                //3 - Abre o arquivo de origem
                XmlDocument origem = new XmlDocument();
                origem.Load(arquivoDestino);
                //4 - Substitiu as variáveis de local de gravacao
                var xmlStr = origem.OuterXml.Replace("{storageLog}", destinoLog);
                //5 - Abre o arquivo de destino
                XmlDocument destino = new XmlDocument();
                destino.LoadXml(xmlStr);
                destino.Save(arquivoDestino);
            }
            catch (FileNotFoundException)
            {
                throw new AccessViolationException("O arquivo " + arquivoLayout + " não foi encontrado.");
            }
            catch (AccessViolationException)
            {
                throw new AccessViolationException("O arquivo " + arquivoDestino + " está aberto e não pode ser alterado.");
            }
        }

        private void SalvarLayoutConfiguracaoLog(Dictionary<string, bool> logsAtivos)
        {
            string arquivoLayout = @"c:\temp\app_data\layout_LogTelefonia.xml";

            var logsValues = logsAtivos.Select(e => e.Key.ToArray());
            var logs = string.Join(",", from e in logsAtivos select e.Key + "=" + (e.Value?"1":"0"));

            XmlDocument arquivo = new XmlDocument();
            arquivo.Load(arquivoLayout);

            if(arquivo != null)
            {
                XmlNode node = arquivo.SelectSingleNode("configuration/configSections/activeLog");
                node.Attributes.Item(0).Value = logs;
                arquivo.Save(arquivoLayout);
            }
        }

        private void DesabilitarLogs(Dictionary<string, bool> statusLogs)
        {
            string arquivoAtual = @"c:\temp\LogTelefonia.xml";
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(arquivoAtual);

                foreach (var item in statusLogs.Where(e => !e.Value))
                {
                    var node = document.SelectNodes($"/configuration/log4net/appender[@name='{item.Key}']");                    
                    node?.Item(0)?.RemoveAll();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível abrir o arquivo de configuração XML do Log");
            }
            document.Save(arquivoAtual);
        }
    }
}
