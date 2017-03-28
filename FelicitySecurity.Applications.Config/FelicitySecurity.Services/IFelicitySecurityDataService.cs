using FelicitySecurity.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FelicitySecurity.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IFelicitySecurityDataService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        void DoWork();
        void AddAdministrator(Administrators_dto item);
        List<Administrators_dto> FindAllAdministrators();
        void AddMember(Members_dto item);
        List<Members_dto> FindAllMembers();
        void AddFaces(Faces_dto item);
        List<Faces_dto> FindAllMembersFaces();
        void AddStaff(Staff_dto item);
        List<Staff_dto> FindALLStaff(Staff_dto item);
        void RemoveAdministrator(int administratorId);
        void UpdateAdministrator(Administrators_dto item);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
