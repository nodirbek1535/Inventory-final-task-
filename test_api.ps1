$baseUrl = "http://localhost:5045/api"

function Test-Endpoint {
    param($method, $path, $body)
    
    Write-Host "Testing $method $path ..." -ForegroundColor Cyan
    $jsonBody = ($body | ConvertTo-Json -Depth 5)
    try {
        $params = @{
            Uri = "$baseUrl$path"
            Method = $method
            ContentType = "application/json"
        }
        if ($body) { $params.Body = $jsonBody }
        
        $response = Invoke-RestMethod @params
        Write-Host "Success! Status: 200/201" -ForegroundColor Green
        return $response
    } catch {
        Write-Host "Failed! Error: $($_.Exception.Message)" -ForegroundColor Red
        if ($_.Exception.Response) {
            $reader = New-Object System.IO.StreamReader($_.Exception.Response.GetResponseStream())
            $errBody = $reader.ReadToEnd()
            Write-Host "Response Body: $errBody" -ForegroundColor Yellow
        }
        return $null
    }
}

Write-Host "--- STARTING API TESTS ---" -ForegroundColor Yellow

# 1. User Test
$now = [DateTime]::UtcNow.ToString("o")
$user = @{
    id = "550e8400-e29b-41d4-a716-446655440000"
    userName = "Nodirbek"
    email = "nodirbek@example.com"
    passwordHash = "hash"
    role = 0 # UserRole.User
    language = "eng"
    theme = "dark"
    isBlocked = $false
    createdAt = $now
    updatedAt = $now
}
Test-Endpoint "Post" "/Users" $user

# 2. Inventory Test
$inventory = @{
    id = "a1b2c3d4-e5f6-4a5b-bcde-f1e2d3c4b5a6"
    title = "Electronics"
    description = "My collection"
    category = "Tech"
    imageUrl = "http://example.com/img.png"
    isPublic = $true
    ownerId = "550e8400-e29b-41d4-a716-446655440000"
    version = 1
    createdAt = $now
    updatedAt = $now
}
Test-Endpoint "Post" "/Inventories" $inventory

Write-Host "--- TESTS FINISHED ---" -ForegroundColor Yellow
