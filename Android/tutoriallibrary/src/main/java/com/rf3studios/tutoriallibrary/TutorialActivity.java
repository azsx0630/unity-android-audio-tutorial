package com.rf3studios.tutoriallibrary;

import android.content.Context;
import android.media.AudioManager;
import android.media.SoundPool;
import android.os.Bundle;

import com.unity3d.player.UnityPlayerActivity;

public class TutorialActivity extends UnityPlayerActivity
{
    public static Context ctx;

    private SoundPool mSoundPool;
    private int[]     mSoundIds;

    @Override
    protected void onCreate(final Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);

        ctx = this;

        // Initialize our audio files
        initAudio();
    }

    /**
     * Initializes our SoundPool object and sets up the audio references
     */
    private void initAudio()
    {
        // Creates a new SoundPool object that will stream the audio sources
        mSoundPool = new SoundPool(20, AudioManager.STREAM_MUSIC, 0);

        // Create a new array that will hold the audio ids
        mSoundIds = new int[3];

        // Load the audio files
        mSoundIds[0] = mSoundPool.load(ctx, R.raw.hit_01, 1);
        mSoundIds[1] = mSoundPool.load(ctx, R.raw.hit_02, 1);
        mSoundIds[2] = mSoundPool.load(ctx, R.raw.hit_03, 1);
    }

    /**
     * Plays the file that is associated with the audioIndex and returns the resource ref
     *
     * @param audioIndex
     *         The index of the audio file in the mSoundsIds array
     * @param isForever
     *         Whether or not the stream should play forever
     *
     * @return The resource reference of the audio file
     */
    public int playAudio(final int audioIndex, final boolean isForever)
    {
        return mSoundPool.play(mSoundIds[audioIndex], 1f, 1f, 0, isForever ? -1 : 0, 1f);
    }
}