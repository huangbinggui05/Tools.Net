using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlSerialization
{
    /* 样例如下
    <?xml version='1.0' encoding='utf-8' ?>
    <Info>
        <Operation>GetBestAndExcellentTopics</Operation>
        <Configuration> 
           <StartDateTime></StartDateTime>
           <EndDateTime></EndDateTime>
        </Configuration>
    </Info>*/
    /// <summary>
    /// 接口输入xml参数
    /// </summary>
    [XmlRoot("Info")]
    public class XmlModel
    {
        [XmlElement("Operation")]
        public string Operation { get; set; }
        [XmlElement("Configuration")]
        public Configuration Configuration { get; set; }
    }
    public class Configuration
    {
        [XmlElement("StartDateTime")]
        public string StartDateTime { get; set; }
        [XmlElement("EndDateTime")]
        public string EndDateTime { get; set; }
    }
}
