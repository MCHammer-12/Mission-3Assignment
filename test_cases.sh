#!/bin/bash
# Test script for quote analyzer

cd /Users/michaelhammer/Downloads/Mission3Assignment-master

echo "=== Test 1: Basic - 'testing' ==="
echo "testing" | dotnet run --no-build 2>/dev/null || echo "testing" | dotnet run 2>/dev/null

echo -e "\n=== Test 2: Spaces and numbers - 'testing testing 1 2 3' ==="
echo "testing testing 1 2 3" | dotnet run --no-build 2>/dev/null || echo "testing testing 1 2 3" | dotnet run 2>/dev/null

echo -e "\n=== Test 3: Case-insensitivity + punctuation - 'AaA, bb! Zz?' ==="
echo "AaA, bb! Zz?" | dotnet run --no-build 2>/dev/null || echo "AaA, bb! Zz?" | dotnet run 2>/dev/null

echo -e "\n=== Test 4: Long quote ==="
echo "ask not what your country can do for you ask what you can do for your country" | dotnet run --no-build 2>/dev/null || echo "ask not what your country can do for you ask what you can do for your country" | dotnet run 2>/dev/null
