/*
 * Copyright (C) 2015 Zhang Rui <bbcallen@gmail.com>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Java.IO;
using TV.Danmaku.Ijk.Media.Player.Misc;

namespace IjkplayerXamarin.Droid
{



    public class FileMediaDataSource :Java.Lang.Object, IMediaDataSource
    {
        private RandomAccessFile mFile;
        private long mFileSize;

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public FileMediaDataSource(java.io.File file) throws java.io.IOException
        public FileMediaDataSource(File file)
        {
            mFile = new RandomAccessFile(file, "r");
            mFileSize = mFile.Length();
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: @Override public int readAt(long position, byte[] buffer, int offset, int size) throws java.io.IOException
        public int ReadAt(long position, byte[] buffer, int offset, int size)
        {
            if (mFile.FilePointer != position)
            {
                mFile.Seek(position);
            }

            if (size == 0)
            {
                return 0;
            }

            return mFile.Read(buffer, 0, size);
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: @Override public long getSize() throws java.io.IOException
        public   long Size
        {
            get
            {
                return mFileSize;
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: @Override public void close() throws java.io.IOException
        public void Close()
        {
            mFileSize = 0;
            mFile.Close();
            mFile = null;
        }
    }

}