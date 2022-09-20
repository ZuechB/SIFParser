using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFParser
{
    public class SIFReader
    {
        public async Task<List<SIFFile>> ReadFile(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);

            var reader = new StreamReader(stream);
            var file = await reader.ReadToEndAsync();
            reader.Close();

            return await ReadSIF(file);
        }

        public async Task<List<SIFFile>> Read(string fileName)
        {
            var reader = new StreamReader(fileName);
            var file = await reader.ReadToEndAsync();
            reader.Close();

            return await ReadSIF(file);
        }

        private async Task<List<SIFFile>> ReadSIF(string file)
        {
            var listSif = new List<SIFFile>();

            var rows = file.Split('\n');

            SIFFile sif = null;
            foreach (var row in rows)
            {
                var index = row.IndexOf("=");
                if (index == -1)
                {
                    continue;
                }

                var key = row.Remove(index).ToString().Trim().ToLower();
                var value = row.Remove(0, index + 1).ToString().Trim();

                if (key == "pn")
                {
                    if (sif != null)
                    {
                        listSif.Add(sif);
                    }
                    sif = new SIFFile();
                }

                ParseValue(key, value, ref sif);
            }

            listSif.Add(sif);
            sif = new SIFFile();

            return listSif;
        }

        private void ParseValue(string key, string value, ref SIFFile sIFObj)
        {
            switch (key)
            {
                case "pn": // Product Number
                    sIFObj.ProductNumber = value;
                    break;
                case "pd": // Product Description
                    sIFObj.ProductDescription = value;
                    break;
                case "mc": // Manufacturer Code
                    sIFObj.ManufacturerCode = value;
                    break;
                case "tg":
                    sIFObj.SideMark = value;
                    break;
                case "qt":
                    sIFObj.Quantity = value;
                    break;
                case "pl":
                    sIFObj.ListPrice = value;
                    break;
                case "on":
                    sIFObj.OptionNumber = value;
                    break;
                case "od":
                    sIFObj.OptionDescription = value;
                    break;
                case "an":
                    sIFObj.AttributeNumber = value;
                    break;
                case "ad":
                    sIFObj.AttributeDescription = value;
                    break;
                case "pv":
                    sIFObj.ProductPicture = value;
                    break;
                case "dxsc":
                    sIFObj.DesignManagerSalesCategory = value;
                    break;
                case "dxbd":
                    sIFObj.ItemBudgetAmount = value;
                    break;
                case "dxlc":
                    sIFObj.LocationCode = value;
                    break;
                case "dxln":
                    sIFObj.LocationName = value;
                    break;
                case "og":
                    sIFObj.Color = value;
                    break;
                case "de":

                    var manuName = "";
                    var index = value.IndexOf("(");
                    if (index != -1)
                    {
                        manuName = value.Remove(index);
                    }

                    sIFObj.ManufacturerName = manuName;
                    break;
            }
        }
    }
}
