#pragma once
#include <cstdint>
#include <cstdio>

struct NativeRunAlgInfo
{
    std::uint32_t t1;
    std::uint32_t t2;
};

inline void NativeRun(const void* buffer, std::size_t size, NativeRunAlgInfo& info)
{
    if (!buffer || size == 0)
        return;

    const std::uint8_t* bytes = static_cast<const std::uint8_t*>(buffer);

    info.t1 += bytes[0];
    info.t2 += static_cast<std::uint32_t>(size);

    std::printf("NativeRun: t1=%u, t2=%u, firstByte=%u, size=%zu\n",
        info.t1, info.t2, bytes[0], size);
    std::fflush(stdout);
}