using System.Collections.Generic;

namespace Kraskal_basic.DSF
{
    public abstract class Dsf
    {
        public abstract void Set(int temp);
        public abstract void Union(int first, int second);
        public abstract int Find(int temp);
    }
    
    public class DsfNative : Dsf
    {
        List<int> parent = new List<int>();
        
        public override void Set(int temp)
        {
            this.parent.Add(temp);
        }

        public override int Find(int temp)
        {
            while (true)
            {
                if (temp == this.parent[temp])
                {
                    return temp;
                }
                else
                {
                    temp = this.parent[temp];
                }
            }
        }

        public override void Union(int first, int second)
        {
            int fir = Find(first);
            int sec = Find(second);
            if (fir != sec)
            {
                this.parent[sec] = fir;
            }
        }
    }
    
    public class DsfForest : Dsf
    {
        List<int> parent = new List<int>();
        List<int> rang = new List<int>();
        
        public override void Set(int temp)
        {
            this.parent.Add(temp);
            this.rang.Add(0);
        }
        
        public override int Find(int temp)
        {
            if (this.parent[temp] != temp)
            {
                this.parent[temp] = Find(this.parent[temp]);
            }
            return this.parent[temp];
        }

        public override void Union(int first, int second)
        {
            int fir = Find(first);
            int sec = Find(second);
            if (this.rang[fir] == this.rang[sec])
            {
                this.rang[fir]++;
            }
            else
            {
                if (fir == sec)
                {
                    return;
                }
            }
            if (this.rang[fir] < this.rang[sec])
            {
                this.parent[fir] = sec;
            }
            else
            {
                this.parent[sec] = fir;
            }
        }
        
    }
}