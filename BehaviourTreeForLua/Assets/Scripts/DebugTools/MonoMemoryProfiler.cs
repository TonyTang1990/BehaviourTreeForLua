/*
 * Description:             MemoryProfiler.cs
 * Author:                  TONYTANG
 * Create Date:             2018/08/08
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

/// <summary>
/// MemoryProfiler.cs
/// ��ª���ڴ�ͳ�ƹ���(ͳ���йܵ�Mono�ڴ�)
/// </summary>
public class MonoMemoryProfiler : SingletonTemplate<MonoMemoryProfiler> {

    /// <summary>
    /// �ڴ�Profile����
    /// </summary>
    public enum MemoryProfilerType
    {
        CSharp_GC = 1,          // CS GCͳ��
        Unity_Profiler = 2      // Unity Profiler�ӿ�ͳ��
    }

    /// <summary>
    /// ��ǰ�ڴ�ͳ������
    /// </summary>
    private MemoryProfilerType mCurrentMemoryProfilerType = MemoryProfilerType.Unity_Profiler;

    /// <summary>
    /// �ڴ��ǩ��
    /// </summary>
    private string mTagName;
    
    /// <summary>
    /// ��ʼͳ��ʱ�ܹ�ʹ�õ�Mono�ڴ�
    /// </summary>
    private long mTotalUsedMonoMemory_Begin;

    /// <summary>
    /// ����ͳ��ʱ�ܹ�ʹ�õ�Mono�ڴ�
    /// </summary>
    private long mTotalUsedMonoMemory_End;

    /// <summary>
    /// ���õ�ǰ�ڴ�ͳ������
    /// </summary>
    /// <param name="mpt"></param>
    public void setMemoryProfilerType(MemoryProfilerType mpt)
    {
        mCurrentMemoryProfilerType = mpt;
    }

    /// <summary>
    /// �����ڴ�ͳ��Tag
    /// </summary>
    /// <param name="tag"></param>
    public void beginMemorySample(string tag)
    {
        if(!tag.IsNullOrEmpty())
        {
            mTagName = tag;
            if (mCurrentMemoryProfilerType == MemoryProfilerType.CSharp_GC)
            {
                // ȷ���õ���ȷ����ʼHeap Memory Size
                mTotalUsedMonoMemory_Begin = GC.GetTotalMemory(true);
            }
            else if (mCurrentMemoryProfilerType == MemoryProfilerType.Unity_Profiler)
            {
                mTotalUsedMonoMemory_Begin = Profiler.GetMonoUsedSizeLong();
            }
        }
        else
        {
            Debug.LogError("MonoMemoryProfiler��Tag����Ϊ��!");
        }
    }

    /// <summary>
    /// �����ڴ�ͳ��
    /// </summary>
    public void endMemorySample()
    {
        if(!mTagName.IsNullOrEmpty())
        {
            if (mCurrentMemoryProfilerType == MemoryProfilerType.CSharp_GC)
            {
                mTotalUsedMonoMemory_End = GC.GetTotalMemory(false);
            }
            else if (mCurrentMemoryProfilerType == MemoryProfilerType.Unity_Profiler)
            {
                mTotalUsedMonoMemory_End = Profiler.GetMonoUsedSizeLong();
            }

            var heapmemoryoffset = mTotalUsedMonoMemory_End - mTotalUsedMonoMemory_Begin;            
            Debug.Log(string.Format("Memory Tag : {0}", mTagName));
            Debug.Log(string.Format("Current Memory Size = {0}", mTotalUsedMonoMemory_End));
            Debug.Log(string.Format("Pre Memory Size = {0}", mTotalUsedMonoMemory_Begin));
            Debug.Log(string.Format("Memory Offset = {0}", heapmemoryoffset));
            mTagName = string.Empty;
        }
    }
}