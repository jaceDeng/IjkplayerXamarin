using Android.App;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

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
using IMediaController = IjkplayerXamarin.Droid.IMediaController;
namespace IjkplayerXamarin.Droid
{


    public class AndroidMediaController : Android.Widget.MediaController,  IMediaController
    {
        private ActionBar mActionBar;

        public AndroidMediaController(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            initView(context); 
        }

        public AndroidMediaController(Context context, bool useFastForward) : base(context, useFastForward)
        {
            initView(context);
        }

        public AndroidMediaController(Context context) : base(context)
        {
            initView(context);
        }

        private void initView(Context context)
        {
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public void setSupportActionBar(@Nullable android.support.v7.app.ActionBar actionBar)
        public virtual ActionBar SupportActionBar
        {
            set
            {
                mActionBar = value;
                if (IsShowing)
                {
                    value.Show();
                }
                else
                {
                    value.Hide();
                }
            }
        }

         
        public virtual void Show()
        {
            base.Show();
            if (mActionBar != null)
            {
                mActionBar.Show();
            }
        }

        public virtual void Hide()
        {
            base.Hide();
            if (mActionBar != null)
            {
                mActionBar.Hide();
            }
            foreach (View view in mShowOnceArray)
            {
                view.Visibility = ViewStates.Gone;// View.GONE;
            }
            mShowOnceArray.Clear();
        }

        //----------
        // Extends
        //----------
        private List<View> mShowOnceArray = new List<View>();

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public void showOnce(@NonNull android.view.View view)
        public virtual void ShowOnce(View view)
        {
            mShowOnceArray.Add(view);
            view.Visibility = ViewStates.Visible; //View.VISIBLE;
            Show();
        }

        public void Show(int timeout)
        {
            throw new System.NotImplementedException();
        }

        public void ShowOnce(View view)
        {
            throw new System.NotImplementedException();
        }
    }

}