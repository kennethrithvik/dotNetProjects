using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEDAL
{
    

    class OptionRepository : IOptionRepository
    {
        private OEEntity.DataSets.OE mydataset;
        private OEEntity.DataSets.OETableAdapters.CorrectOptionTableAdapter taCO;
        private OEEntity.DataSets.OETableAdapters.OptionsTableAdapter taOp;

        public OptionRepository()
        {
            mydataset = new OEEntity.DataSets.OE();

            taCO = new OEEntity.DataSets.OETableAdapters.CorrectOptionTableAdapter();
            taCO.Fill(mydataset.CorrectOption);

            taOp = new OEEntity.DataSets.OETableAdapters.OptionsTableAdapter();
            taOp.Fill(mydataset.Options);
        }
 
        public List<OEEntity.Option> GetCOptionByQID(byte qid)
        {
            OEEntity.Option cop;
            List<OEEntity.Option> colist = new List<OEEntity.Option>();
            OEEntity.DataSets.OE.CorrectOptionDataTable codt;
            codt = mydataset.CorrectOption;//taCO.GetDataBy(item.qid);
            foreach (OEEntity.DataSets.OE.CorrectOptionRow item1 in codt.Rows)
            {
                if (qid == item1.qid)
                {
                    cop = new OEEntity.Option();
                    cop.oid = item1.oid;
                    cop.option = item1.OptionsRow.name;
                    colist.Add(cop);
                }
            }

            return colist;
        }


        public byte GetOptionByName(string nam)
        {
            OEEntity.Option cop;
            List<OEEntity.Option> colist = new List<OEEntity.Option>();
            OEEntity.DataSets.OE.OptionsDataTable odt;
            odt = mydataset.Options;//taCO.GetDataBy(item.qid);
            foreach (OEEntity.DataSets.OE.OptionsRow item1 in odt.Rows)
            {
                if (nam.Equals(item1.name))
                {
                    return item1.oid;
                }
            }

            return 0;
        }

        public List<OEEntity.Option> GetAllByID(byte qid)
        {
            OEEntity.Option op;
            List<OEEntity.Option> olist = new List<OEEntity.Option>();
            OEEntity.DataSets.OE.OptionsDataTable odt;
            odt = taOp.GetDataBy1(qid);
            foreach (OEEntity.DataSets.OE.OptionsRow item1 in odt.Rows)
            {
                op = new OEEntity.Option();
                op.oid = item1.oid;
                op.option = item1.name;
                olist.Add(op);
            }

            return olist;
        }

        public void addOptions(OEEntity.Question q)
        {
            byte oid1;
            foreach (var item in q.options)
            {
                taOp.AddOption(item.option, q.qid);
                taOp.Fill(mydataset.Options);
                oid1 = GetOptionByName(item.option);
                if(q.coptions.Contains(item))
                    addCOption(q.qid,oid1);
            }
        }

        public void addCOption(byte qid,byte oid)
        {
            taCO.AddCOption(qid, oid);
            taCO.Fill(mydataset.CorrectOption);
            //mydataset.CorrectOption.AddCorrectOptionRow(qid, oid);
        }
    }
}
