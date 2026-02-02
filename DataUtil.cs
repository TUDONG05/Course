using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace CRUD
{
    internal class DataUtil
    {

        XmlDocument doc;
        XmlElement root;
        string filename;


        public DataUtil()
        {

            filename = "Course.xml";
            doc = new XmlDocument();

            if (!File.Exists(filename))
            {
                XmlElement course = doc.CreateElement("course");
                doc.AppendChild(course);
                doc.Save(filename);


            }
            doc.Load(filename);
            root = doc.DocumentElement;


        }




        public void AddStudent(Student s)
        {
            XmlElement st = doc.CreateElement("student");
            st.SetAttribute("id", s.id);

            XmlElement name = doc.CreateElement("name");
            name.InnerText = s.name;

            XmlElement age = doc.CreateElement("age");
            age.InnerText = s.age;

            XmlElement city = doc.CreateElement("city");
            city.InnerText = s.city;


            st.AppendChild(name);
            st.AppendChild(age);
            st.AppendChild(city);

            root.AppendChild(st);
            doc.Save(filename);



        }


        public bool UpdateStudent(Student s)
        {
            XmlNode stFind = root.SelectSingleNode("student[@id='" + s.id + "']");
            if(stFind!= null)
            {
                XmlElement st = doc.CreateElement("student");
                st.SetAttribute("id", s.id);

                XmlElement name = doc.CreateElement("name");
                name.InnerText = s.name;

                XmlElement age = doc.CreateElement("age");
                age.InnerText = s.age;

                XmlElement city = doc.CreateElement("city");
                city.InnerText = s.city;


                st.AppendChild(name);
                st.AppendChild(age);
                st.AppendChild(city);

                root.ReplaceChild(st, stFind);
                doc.Save(filename);
                return true;
            }
            return false;
        }

        public List<Student> GetAllStudent()
        {
            XmlNodeList nodes = root.SelectNodes("student");
            List<Student> ds = new List<Student>();
            foreach(XmlNode item in nodes)
            {
                Student s = new Student();
                s.id = item.Attributes[0].InnerText;
                s.name = item.SelectSingleNode("name").InnerText;
                s.age = item.SelectSingleNode("age").InnerText;
                s.city = item.SelectSingleNode("city").InnerText;
                ds.Add(s);
            }
            return ds;
        }

        public bool DeleteStudent(string id)
        {
            XmlNode stFind = root.SelectSingleNode("student[@id='" + id + "']");
            if (stFind != null)
            {
                root.RemoveChild(stFind);
                doc.Save(filename);
                return true;
            }
            return false;
        }

        public Student FindByID(string ID)
        {
            XmlNode stFind = root.SelectSingleNode("student[@id='" + ID + "']");
            Student s = null;
            if(stFind!= null)
            {
                s = new Student();
                s.id = stFind.Attributes[0].InnerText;
                s.name = stFind.SelectSingleNode("name").InnerText;
                s.age = stFind.SelectSingleNode("age").InnerText;
                s.city = stFind.SelectSingleNode("city").InnerText;

            }
            return s;
        }


        public Student FindByCity(string city)
        {
            XmlNode stFind = root.SelectSingleNode("student[city='" + city+"']");
            Student s = null;
            if (stFind!=null){
                s = new Student();
                s.id = stFind.Attributes[0].InnerText;
                s.name = stFind.SelectSingleNode("name").InnerText;
                s.age = stFind.SelectSingleNode("age").InnerText;
                s.city = stFind.SelectSingleNode("city").InnerText;

            }
            return s;
        }
    }


}
