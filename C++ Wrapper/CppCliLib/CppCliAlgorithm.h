#pragma once

#include "NativeAlgo.h"

#using <mscorlib.dll>

using namespace System;

namespace CppCliLib
{
    public value struct RunAlgInfoManaged
    {
        System::UInt32 t1;
        System::UInt32 t2;
    };

    public ref class CppCliAlgorithm
    {
    public:
        CppCliAlgorithm();
        ~CppCliAlgorithm();
        !CppCliAlgorithm();

        bool InitAlgorithm(Object^ info);
        bool Run(array<System::Byte>^ buffer, RunAlgInfoManaged% info);

    private:
        NativeRunAlgInfo* _nativeInfo;
    };
}