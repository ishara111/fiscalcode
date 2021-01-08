using System;
using System.Globalization;
class final
{
    static void Main(string[] args)
    {
        Console.Write("Enter First name : ");
        string n1=Console.ReadLine();
        string name=n1.ToUpper(new CultureInfo("en-US", false));
        Console.Write("Enter surname : ");
        string n2=Console.ReadLine();
        string sname=n2.ToUpper(new CultureInfo("en-US", false));
        int valgen=0;
        string gen;
	    do//GENDER VALIDATION
	    {
            Console.Write("Enter Gender M/F : ");
            gen=Console.ReadLine();
            if(gen =="M" | gen=="F")
            {
                valgen=1;
            }
		}while(valgen==0);

        string dob;
        bool res;
        do
        {
            Console.Write("Enter DOB dd/mm/yyyy : ");
            dob=Console.ReadLine();
            final m=new final();
            res =m.DateVal(dob);  
        } while (res==false);
        string[,] A={{name,sname},{gen,dob}};
        final s=new final();
        int res2=s.Ccount(sname);
        string sfiscal="";
        string nfiscal="";
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        if(res2 >= 3)//surname fiscal start
        {
            string res3=s.sur1cal(sname);
            sfiscal=res3;
        }else if(res2 < 3)
        {
            string res3=s.sur2cal(sname);
            sfiscal=res3;
        }else if(sname.Length<3)
        {
           sfiscal=(sname+"X"); 
        }     //surname fiscal end
        
        //name fiscal start
        int res4=s.Ccount(name);
        if(res4 == 3)
        {
            string res5=s.sur1cal(name);
            nfiscal=res5;
        }else if(res4>3)
        {
            string res5=s.n1cal(name);
            nfiscal=res5;
        }else if(res4<3)
        {
            string res5=s.sur2cal(name);
            nfiscal=res5;
        }else if(name.Length<3)
        {
            nfiscal=(name+"X");
        }
        //NAME FISCAL END

        //DOB AND GENDER FISCAL START
        string yearfiscal=dob.Substring(8,2);
        string month=dob.Substring(3,2);
        string mfiscal=s.getLetter(month);
        string gfiscal="";
        int gffiscal=0;
        if(gen =="M")
        {
            gfiscal=dob.Substring(0,2);
        }else if(gen =="F")
        {
            gffiscal=int.Parse(dob.Substring(0,2));
            gffiscal=gffiscal+40;
            gfiscal=gffiscal.ToString();
        }
        //DOB AND GENDER FISCAL END
        Console.WriteLine("Fiscal Code is "+sfiscal+nfiscal+yearfiscal+mfiscal+gfiscal);
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        Console.ReadLine();
    }


// METHODS

//DATE VALIDATION
    bool DateVal(string tempDate)
    { 
        DateTime fromDateValue; 
        var formats = new[] { "dd/MM/yyyy"}; 
        if (DateTime.TryParseExact(tempDate, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue))
        { 
            return true;
        } 
        else
        { 
            return false;
        }
    }

//CONSANANT COUNTER

   int Ccount(string str)
    {
        int vowel=0;
    int cons = 0;
    int len = str.Length;
    int i;
    int c=0;
    char[] conc=new char[len];

    for(i=0; i<len; i++)
    {

        if(str[i]=='A' || str[i]=='E' || str[i]=='I' || str[i]=='O' || str[i]=='U')
        {
            vowel++;
        }
        else if((str[i]>='A' && str[i]<='Z'))
        {
            cons++;
            conc[c]=(str[i]);
            c++;
        }
    }
    return cons;
    }


    //surname 3 or more consanants and name equal to 3 consonants
    string sur1cal(string str)
    {
        int vowel=0;
    int cons = 0;
    int len = str.Length;
    int i;
    int c=0;
    string[] conc=new string[len];

    for(i=0; i<len; i++)
    {

        if(str[i]=='A' || str[i]=='E' || str[i]=='I' || str[i]=='O' || str[i]=='U')
        {
            vowel++;
        }
        else if((str[i]>='A' && str[i]<='Z'))
        {
            cons++;
            conc[c]=Char.ToString(str[i]);
            c++;
        }
    }
    string sur=(conc[0]+conc[1]+conc[2]);
    return sur;
    }

//SURNAME AND NAME LESS THAN 3 CONCONSNTS
    string sur2cal(string str)
    {
        int vowel=0;
    int cons = 0;
    int len = str.Length;
    int i;
    int c=0;
    int f=0;
    string[] conc=new string[len];
    string[] conv=new string[len];

    for(i=0; i<len; i++)
    {

        if(str[i]=='A' || str[i]=='E' || str[i]=='I' || str[i]=='O' || str[i]=='U')
        {
            vowel++;
            conv[f]=Char.ToString(str[i]);
            f++;
        }
        else if((str[i]>='A' && str[i]<='Z'))
        {
            cons++;
            conc[c]=Char.ToString(str[i]);
            c++;
        }
    }
    string sur=(conc[0]+conc[1]+conv[0]);
    return sur;
    }

    //NAME WITH MORE THAN 3 CONCANANTS
    string n1cal(string str)
    {
        int vowel=0;
    int cons = 0;
    int len = str.Length;
    int i;
    int c=0;
    string[] conc=new string[len];

    for(i=0; i<len; i++)
    {

        if(str[i]=='A' || str[i]=='E' || str[i]=='I' || str[i]=='O' || str[i]=='U')
        {
            vowel++;
        }
        else if((str[i]>='A' && str[i]<='Z'))
        {
            cons++;
            conc[c]=Char.ToString(str[i]);
            c++;
        }
    }
    string n1=(conc[0]+conc[2]+conc[3]);
    return n1;
    }


    //GET letter WITH MONTH

    string getLetter(string m)
    {
        switch (m)
        {
            case "01":return "A"; break;
            case "02":return "B"; break;
            case "03":return "C"; break;
            case "04":return "D"; break;
            case "05":return "E"; break;
            case "06":return "H"; break;
            case "07":return "L"; break;
            case "08":return "M"; break;
            case "09":return "P"; break;
            case "10":return "R"; break;
            case "11":return "S"; break;
            case "12":return "T"; break;
            default:return "invalid"; break;
        }
    }

    
}