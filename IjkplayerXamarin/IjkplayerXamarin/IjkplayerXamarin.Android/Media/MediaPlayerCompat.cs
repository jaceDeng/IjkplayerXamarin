using System.Text;
using TV.Danmaku.Ijk.Media.Player;

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

namespace IjkplayerXamarin.Droid
{
	 
	public class MediaPlayerCompat
	{
		public static string getName(IMediaPlayer mp)
		{
			if (mp == null)
			{
				return "null";
			}
			else if (mp is TextureMediaPlayer)
			{
				StringBuilder sb = new StringBuilder("TextureMediaPlayer <");
				IMediaPlayer internalMediaPlayer = ((TextureMediaPlayer) mp).InternalMediaPlayer;
				if (internalMediaPlayer == null)
				{
					sb.Append("null>");
				}
				else
				{
					sb.Append(internalMediaPlayer.GetType().Name);
					sb.Append(">");
				}
				return sb.ToString();
			}
			else
			{
				return mp.GetType().Name;
			}
		}

		public static IjkMediaPlayer getIjkMediaPlayer(IMediaPlayer mp)
		{
			IjkMediaPlayer ijkMediaPlayer = null;
			if (mp == null)
			{
				return null;
			}
			if (mp is IjkMediaPlayer)
			{
				ijkMediaPlayer = (IjkMediaPlayer) mp;
			}
			else if (mp is MediaPlayerProxy && ((MediaPlayerProxy) mp).InternalMediaPlayer is IjkMediaPlayer)
			{
				ijkMediaPlayer = (IjkMediaPlayer)((MediaPlayerProxy) mp).InternalMediaPlayer;
			}
			return ijkMediaPlayer;
		}

		public static void selectTrack(IMediaPlayer mp, int stream)
		{
			IjkMediaPlayer ijkMediaPlayer = getIjkMediaPlayer(mp);
			if (ijkMediaPlayer == null)
			{
				return;
			}
			ijkMediaPlayer.SelectTrack(stream);
		}

		public static void deselectTrack(IMediaPlayer mp, int stream)
		{
			IjkMediaPlayer ijkMediaPlayer = getIjkMediaPlayer(mp);
			if (ijkMediaPlayer == null)
			{
				return;
			}
            ijkMediaPlayer.DeselectTrack(stream);
		}

		public static int getSelectedTrack(IMediaPlayer mp, int trackType)
		{
			IjkMediaPlayer ijkMediaPlayer = getIjkMediaPlayer(mp);
			if (ijkMediaPlayer == null)
			{
				return -1;
			}
			return ijkMediaPlayer.GetSelectedTrack(trackType);
		}
	}

}