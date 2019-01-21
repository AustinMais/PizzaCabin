﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PizzaCabin1
{
    using System.Runtime.Serialization;


    public class Rootobject
    {
        public Scheduleresult ScheduleResult { get; set; }
    }

    public class Scheduleresult
    {
        public Schedule[] Schedules { get; set; }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "TeamSchedule", Namespace = "http://schemas.datacontract.org/2004/07/PizzaCabinInc")]
    public partial class TeamSchedule : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private PizzaCabin1.Schedule[] SchedulesField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public PizzaCabin1.Schedule[] Schedules
        {
            get
            {
                return this.SchedulesField;
            }
            set
            {
                this.SchedulesField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Schedule", Namespace = "http://schemas.datacontract.org/2004/07/PizzaCabinInc")]
    public partial class Schedule : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private int ContractTimeMinutesField;

        private System.DateTime DateField;

        private bool IsFullDayAbsenceField;

        private string NameField;

        private System.Guid PersonIdField;

        private PizzaCabin1.Activity[] ProjectionField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ContractTimeMinutes
        {
            get
            {
                return this.ContractTimeMinutesField;
            }
            set
            {
                this.ContractTimeMinutesField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date
        {
            get
            {
                return this.DateField;
            }
            set
            {
                this.DateField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsFullDayAbsence
        {
            get
            {
                return this.IsFullDayAbsenceField;
            }
            set
            {
                this.IsFullDayAbsenceField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid PersonId
        {
            get
            {
                return this.PersonIdField;
            }
            set
            {
                this.PersonIdField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public PizzaCabin1.Activity[] Projection
        {
            get
            {
                return this.ProjectionField;
            }
            set
            {
                this.ProjectionField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Activity", Namespace = "http://schemas.datacontract.org/2004/07/PizzaCabinInc")]
    public partial class Activity : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private string ColorField;

        private string DescriptionField;

        private System.DateTime StartField;

        private int minutesField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Color
        {
            get
            {
                return this.ColorField;
            }
            set
            {
                this.ColorField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Start
        {
            get
            {
                return this.StartField;
            }
            set
            {
                this.StartField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int minutes
        {
            get
            {
                return this.minutesField;
            }
            set
            {
                this.minutesField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IPizzaCabinInc")]
public interface IPizzaCabinInc
{

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPizzaCabinInc/Schedule", ReplyAction = "http://tempuri.org/IPizzaCabinInc/ScheduleResponse")]
    PizzaCabin1.TeamSchedule Schedule(string date);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPizzaCabinInc/Schedule", ReplyAction = "http://tempuri.org/IPizzaCabinInc/ScheduleResponse")]
    System.Threading.Tasks.Task<PizzaCabin1.TeamSchedule> ScheduleAsync(string date);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IPizzaCabinIncChannel : IPizzaCabinInc, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class PizzaCabinIncClient : System.ServiceModel.ClientBase<IPizzaCabinInc>, IPizzaCabinInc
{

    public PizzaCabinIncClient()
    {
    }

    public PizzaCabinIncClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
    {
    }

    public PizzaCabinIncClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public PizzaCabinIncClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public PizzaCabinIncClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
    {
    }

    public PizzaCabin1.TeamSchedule Schedule(string date)
    {
        return base.Channel.Schedule(date);
    }

    public System.Threading.Tasks.Task<PizzaCabin1.TeamSchedule> ScheduleAsync(string date)
    {
        return base.Channel.ScheduleAsync(date);
    }
}
