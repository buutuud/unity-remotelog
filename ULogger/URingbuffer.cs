using System;
using System.Collections.Generic;
using System.Text;

namespace ULogger
{
    public class ISetterInterface
    {
        public virtual void Set(ISetterInterface pOther) { }
    }

    public class URingbuffer<T> where T : ISetterInterface, new()
    {
        private int mMaxSize = 0;
        private List<T> mCache = new List<T>();
        private int mReaderPos = 0;
        private int mWritePos = 0;
        private int mCurSize = 0;

        public URingbuffer(int nSize = 1024)
        {
            mMaxSize = nSize;

            for (int nIndex = 0; nIndex < mMaxSize; nIndex++)
            {
                mCache.Add(new T());
            }
        }

        public bool Push(T pValue)
        {
            if(mCurSize >= mMaxSize)
            {
                return false;
            }
            mCache[mWritePos].Set(pValue);
            mWritePos = mWritePos >= mMaxSize - 1 ? 0 : mWritePos + 1;
            mCurSize++;
            return true;
        }

        public T Pop()
        {
            T tRet = Peek();
            if (tRet != null)
            {
                mReaderPos = mReaderPos >= mMaxSize - 1 ? 0 : mReaderPos + 1;
                mCurSize--;
            }
            return tRet;
        }

        public T Peek()
        {
            if (mCurSize == 0)
            {
                return default(T);
            }
            return mCache[mReaderPos];
        }
        public int Size()
        {
            return mCurSize;
        }
        public void Clear()
        {
            mReaderPos = 0;
            mWritePos = 0;
            mCurSize = 0;
        }
    }
}
