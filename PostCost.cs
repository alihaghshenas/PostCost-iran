using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coollacs.PublicClasses
{
    public class PostCost
    {
        /// <summary>
        /// Calculate COST of Post per Product's Weight and Valume
        /// </summary>
        /// <param name="DestinationType"> 1 = Inside the Province  , 2 = Neighbor Province, 3 = Non Neighbor Province</param>
        /// <param name="Weight"> in Geram</param>
        /// <returns> cost of Post in Tooman </returns>
        /// 


        #region SeperatePackage
        /// Seperate the Packages if the Valume is More than 'Volume Pack 8' (Seperated Package Should be More than 'Volume Pack 3' to be Seperated)
        /// <Attention>!!!This Code Should be in the Controller!!!!</Attention>

        /*List<float> packages = new List<float>();
            float postPrice = 0;

            RefereshPackage:
            if (volume > 54000)
            {
                if ((volume - 54000) >= 6000)
                {
                    float nextPackageVolume = volume - 54000;
                    volume -= 54000;
                    packages.Add(new PostCost().Calculate(Convert.ToByte(type), weight, (int)nextPackageVolume));
                }
                else
                {
                    packages.Add(volume);
                }
                goto RefereshPackage;
            }
            else { 
                packages.Add(new PostCost().Calculate(Convert.ToByte(type), weight, volume));
            }

            ViewBag.postPrice = packages.Sum();*/
        #endregion

        public string Calculate(byte DestinationType, int Weight, int Volume = 0)
        {
            if (Volume < 54000 && Weight < 30000)
            {
                int WeightCost = 0;
                int VolumeCost = 0;
                int OptionsCosts = 0;

                //*******************************************************************************************************
                // Weight Check *****************************************************************************************
                //*******************************************************************************************************
                #region Weight Check
                // Destination = Inside the Province
                //=======================================================================================================
                if (DestinationType == 1)
                {
                    if (Weight <= 500)
                    {
                        WeightCost = 7762;
                    }
                    else if (Weight > 500 && Weight <= 1000)
                    {
                        WeightCost = 10000;
                    }
                    else if (Weight > 1000 && Weight <= 2000)
                    {
                        WeightCost = 13230;
                    }
                    else if (Weight > 2000)
                    {
                        float result = Weight / 1000;


                        //it'a a Decimal
                        if ((Weight % 1000) != 0)
                        {
                            WeightCost = (Convert.ToInt32(result - 1) * 3750) + 13230;
                        }
                        //Not Decimal(Int)
                        else
                        {
                            WeightCost = (Convert.ToInt32(result - 2) * 3750) + 13230;
                        }

                    }
                }

                // Destination = Neighbor Province
                //=======================================================================================================
                else if (DestinationType == 2)
                {
                    if (Weight <= 500)
                    {
                        WeightCost = 10530;
                    }
                    else if (Weight > 500 && Weight <= 1000)
                    {
                        WeightCost = 13500;
                    }
                    else if (Weight > 1000 && Weight <= 2000)
                    {
                        WeightCost = 17145;
                    }
                    else if (Weight > 2000)
                    {
                        float result = Weight / 1000;

                        //it'a a Decimal
                        if ((Weight % 1000) != 0)
                        {
                            WeightCost = (Convert.ToInt32(result + 1) * 3750) + 17145;
                        }
                        //Not Decimal(Int)
                        else
                        {
                            WeightCost = (Convert.ToInt32(result) * 3750) + 17145;
                        }

                    }
                }

                // Destination = Non Neighbor Province
                //=======================================================================================================
                else if (DestinationType == 3)
                {
                    if (Weight <= 500)
                    {
                        WeightCost = 12600;
                    }
                    else if (Weight > 500 && Weight <= 1000)
                    {
                        //WeightCost = 15176;
                        WeightCost = 16800;
                    }
                    else if (Weight > 1000 && Weight <= 2000)
                    {
                        //WeightCost = 22867;
                        WeightCost = 21000;
                    }
                    else if (Weight > 2000)
                    {
                        float result = Weight / 1000;

                        //it'a a Decimal
                        if ((Weight % 1000) != 0)
                        {
                            WeightCost = (Convert.ToInt32(result + 1) * 3375) + 21000;
                        }
                        //Not Decimal(Int)
                        else
                        {
                            WeightCost = (Convert.ToInt32(result) * 3375) + 21000;
                        }

                    }
                }
                #endregion


                //*******************************************************************************************************
                // Valume Check *****************************************************************************************
                //*******************************************************************************************************
                #region Valume Check
                if (Volume != 0)
                {
                    //VolumeCost = Size Price + Glue and Stickers

                    // Size 1
                    //----------------------------------------------------
                    if (Volume <= 1200)
                    {
                        VolumeCost = 2500 + 2000;
                    }
                    // Size 2
                    //----------------------------------------------------
                    else if (Volume > 1200 && Volume <= 3000)
                    {
                        VolumeCost = 3500 + 4000;
                    }
                    // Size 3
                    //----------------------------------------------------
                    else if (Volume > 3000 && Volume <= 6000)
                    {
                        VolumeCost = 5000 + 5000;
                    }
                    // Size 4
                    //----------------------------------------------------
                    else if (Volume > 6000 && Volume <= 12000)
                    {
                        VolumeCost = 7000 + 6000;
                    }
                    // Size 5
                    //----------------------------------------------------
                    else if (Volume > 12000 && Volume <= 17500)
                    {
                        VolumeCost = 9000 + 8000;
                    }
                    // Size 6
                    //----------------------------------------------------
                    else if (Volume > 17500 && Volume <= 30000)
                    {
                        VolumeCost = 19000 + 8000;
                    }
                    // Size 7
                    //----------------------------------------------------
                    else if (Volume > 30000 && Volume <= 31500)
                    {
                        VolumeCost = 19000 + 8000;
                    }
                    // Size 8
                    //----------------------------------------------------
                    else if (Volume > 31500 && Volume <= 54000)
                    {
                        VolumeCost = 26000 + 8000;
                    }
                }
                #endregion


                //*******************************************************************************************************
                // Options **********************************************************************************************
                //*******************************************************************************************************
                #region Adding Options
                OptionsCosts += 3800; // غیر استاندارد
                OptionsCosts += 2000; // غرامت غیر اجباری
                OptionsCosts += 3000; // آگهی تحویل
                #endregion

                //*******************************************************************************************************
                // Result ***********************************************************************************************
                //*******************************************************************************************************

                //Tax
                float TaxPrice = (WeightCost + OptionsCosts) * 0.09f;
                float finalResult = WeightCost + VolumeCost + OptionsCosts + TaxPrice;
                return finalResult.ToString();
            }
            else {
                return "برای اطلاع از قیمت ارسال با فروشگاه تماس بگیرید";
            }
        }
    }
}
