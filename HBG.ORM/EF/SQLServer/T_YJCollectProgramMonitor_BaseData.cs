//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HBG.ORM.EF.SQLServer
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_YJCollectProgramMonitor_BaseData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_YJCollectProgramMonitor_BaseData()
        {
            this.T_YJCollectProgramMonitor_Alm = new HashSet<T_YJCollectProgramMonitor_Alm>();
        }
    
        public System.Guid BaseDataId { get; set; }
        public string MonitorObjIp { get; set; }
        public string MonitorObjLogPath { get; set; }
        public string EvtTyp { get; set; }
        public string AlmLvl { get; set; }
        public string MonitorObjName { get; set; }
        public Nullable<bool> IsNeedChk { get; set; }
        public Nullable<System.Guid> FK_Cron { get; set; }
        public string BaseDataRemark { get; set; }
        public string MonitorPrefixUri { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_YJCollectProgramMonitor_Alm> T_YJCollectProgramMonitor_Alm { get; set; }
        public virtual T_YJCollectProgramMonitor_Cron T_YJCollectProgramMonitor_Cron { get; set; }
    }
}
