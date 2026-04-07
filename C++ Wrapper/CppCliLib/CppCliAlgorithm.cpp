#include "CppCliAlgorithm.h"
#include <vcclr.h>

namespace CppCliLib
{
    CppCliAlgorithm::CppCliAlgorithm()
    {
        _nativeInfo = new NativeRunAlgInfo();
        _nativeInfo->t1 = 0;
        _nativeInfo->t2 = 0;
    }

    CppCliAlgorithm::~CppCliAlgorithm()
    {
        this->!CppCliAlgorithm();
    }

    CppCliAlgorithm::!CppCliAlgorithm()
    {
        if (_nativeInfo != nullptr)
        {
            delete _nativeInfo;
            _nativeInfo = nullptr;
        }
    }

    bool CppCliAlgorithm::InitAlgorithm(Object^ info)
    {
        if (_nativeInfo == nullptr)
            _nativeInfo = new NativeRunAlgInfo();

        _nativeInfo->t1 = 0;
        _nativeInfo->t2 = 0;
        return true;
    }

    bool CppCliAlgorithm::Run(array<System::Byte>^ buffer, RunAlgInfoManaged% info)
    {
        if (_nativeInfo == nullptr || buffer == nullptr || buffer->Length == 0)
            return false;

        _nativeInfo->t1 = info.t1;
        _nativeInfo->t2 = info.t2;

        pin_ptr<System::Byte> pinned = &buffer[0];
        void* nativeBuffer = pinned;

        std::size_t size = static_cast<std::size_t>(buffer->Length);
        NativeRun(nativeBuffer, size, *_nativeInfo);

        info.t1 = _nativeInfo->t1;
        info.t2 = _nativeInfo->t2;

        return true;
    }
}