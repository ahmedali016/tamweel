using noteData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noteLogic
{
   public class clients
    {
        note n = new note();

        public int AddClient(ViewModel.clientView client)
        {
            if (client.clientName!=null&& client.age>0 &&client.departmentId>0&&client.job>0)
            {
                var exist = n.Client.FirstOrDefault(c => c.name == client.clientName);
                if (exist == null)
                {
                    noteData.Model.clients newclient = new noteData.Model.clients();
                    newclient.name = client.clientName;
                    newclient.age = client.age;                    
                    newclient.birthDate = DateTime.Parse(client.birthdate);
                    newclient.departmentId = client.departmentId;
                    newclient.jobId = client.job;
                    newclient.mail = client.mail;
                    newclient.photo = client.photo;
                    newclient.password = client.password;
                    n.Client.Add(newclient);
                    n.SaveChanges();
                    int clientId = newclient.ID;
                    for (int i = 0; i < client.clientAddress.Count; i++)
                    {
                        client.clientAddress[i].clientId = clientId;
                        addAddress(client.clientAddress[i]);
                    }
                    for (int i = 0; i < client.clientPhone.Count; i++)
                    {
                        client.clientPhone[i].clientId = clientId;
                        addPhone(client.clientPhone[i]);
                    }
                    return clientId;
                }
                return 0;
            }
            else
            {
                return 0;
            }

        }
        public void addPhone(ViewModel.phone phone)
        {
            n.ClientPhones.Add(new clientPhone { clientId = phone.clientId, phone = phone.phones });
            n.SaveChanges();
        }
        public void addAddress(ViewModel.address address)
        {
            n.ClientAddresses.Add(new clientAddress { clientId = address.clientId, address = address.addres });
            n.SaveChanges();
        }
        private void deletePhone(int clientId)
        {
            var list = n.ClientPhones.Where(c => c.clientId == clientId).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                n.ClientPhones.Remove(list[i]);
            }
            n.SaveChanges();
        }
        private void deleteAddress(int clientId)
        {
            var list = n.ClientAddresses.Where(c => c.clientId == clientId).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                n.ClientAddresses.Remove(list[i]);
            }
            n.SaveChanges();
        }
        public bool EditClient(ViewModel.clientView client)
        {
            if (client.clientName != string.Empty && client.clientId>0)
            {
                var exist = n.Client.FirstOrDefault(c => c.name == client.clientName && c.ID!=client.clientId);
                if (exist == null)
                {
                    var editclint = n.Client.FirstOrDefault(c => c.ID == client.clientId);
                    editclint.name = client.clientName;
                    editclint.birthDate = client.birthdate != string.Empty ? DateTime.Parse(client.birthdate) : editclint.birthDate;
                    editclint.age = client.age> 0? client.age : editclint.age ;
                    editclint.departmentId = client.departmentId;
                    editclint.jobId = client.job;
                    editclint.mail = client.mail;
                    editclint.photo = client.photo;
                    if(client.password!=string.Empty)
                    editclint.password = client.password;
                    n.SaveChanges();
                    int clientId = client.clientId;
                    deletePhone(clientId);
                    deleteAddress(clientId);
                    for (int i = 0; i < client.clientAddress.Count; i++)
                    {
                        client.clientAddress[i].clientId = client.clientId;
                        addAddress(client.clientAddress[i]);
                    }
                    for (int i = 0; i < client.clientPhone.Count; i++)
                    {
                        client.clientPhone[i].clientId= client.clientId;
                        addPhone(client.clientPhone[i]);
                    }
                    n.SaveChanges();
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteClient(int id)
        {
            if (id > 0)
            {
                var deleteClient = n.Client.FirstOrDefault(c => c.ID == id);
                deleteAddress(id);
                deletePhone(id);
                n.Client.Remove(deleteClient);
                n.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public List<ViewModel.clientView> displayClient()
        {
            var list = n.Client.Select(c => new ViewModel.clientView
            {
                age = c.age.Value,
                birthdate =c.birthDate.ToString(),
                clientId = c.ID,
                clientName = c.name,
                departmentId = c.departmentId,
                departmentName = c.Department.departmentName,
                job = c.jobId,
                jobTitle = c.JobTitle.jobTitleName,
                mail = c.mail,
                password = c.password,
                photo = c.photo,
                clientPhone = (c.clientPhone.Where(p => p.clientId == c.ID).Select(p => new ViewModel.phone { phones = p.phone }).ToList()),
                clientAddress = c.clientAddress.Where(a => a.clientId == c.ID).Select(a => new ViewModel.address { addres = a.address }).ToList()
            });
            return list.ToList();
        }

        public ViewModel.clientView displayClientById(int id)
        {
            var phones = n.ClientPhones.Where(p => p.clientId== id).Select(p => new ViewModel.phone { phones = p.phone }).ToList();
            var addres = n.ClientAddresses.Where(a => a.clientId == id).Select(a => new ViewModel.address { addres = a.address }).ToList();
            var list = n.Client.Where(c => c.ID == id).Select(c => new ViewModel.clientView
            {
                age = c.age.Value,
                birthdate = c.birthDate.ToString(),
                clientId = c.ID,
                clientName = c.name,
                departmentId = c.departmentId,
                departmentName = c.Department.departmentName,
                job = c.jobId,
                jobTitle = c.JobTitle.jobTitleName,
                mail = c.mail,
                password = c.password,
                photo = c.photo,
            }).FirstOrDefault();
            list.clientAddress = addres;
            list.clientPhone = phones;
            return list;
        }
    }
}
