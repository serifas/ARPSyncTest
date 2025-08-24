﻿namespace ARPSynchronos.Interop.Ipc;

public interface IIpcCaller : IDisposable
{
    bool APIAvailable { get; }
    void CheckAPI();
}
