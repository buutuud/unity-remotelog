local skynet = require "skynet"
local socket = require "socket"
--local strings = _libs.strings
local strings = require "strings"
local command = {}
local convert = {}
local queue = {}
local working = {}
local colors = {
    RESET = '\x1b[0m',
    RED = '\x1b[31m',
    GREEN = '\x1b[32m',
    YELLOW = '\x1b[33m',
    BLUE = '\x1b[34m',
    MAGENTA = '\x1b[35m',
    CYAN = '\x1b[36m',
}

-- local tags = {
--     'MoonBox' = colors[GREEN],
--     'Unity' = colors[CYAN],
-- }

function color( tag )
    local s = tag:upper()
    if string.find(s,'ERROR') then
        return colors.RED .. tag .. colors.RESET
    else
        return colors.GREEN .. tag .. colors.RESET
    end
end

function lua_string_split(str, split_char)
    local sub_str_tab = {};
    while (true) do
        local pos = string.find(str, split_char);
        if (not pos) then
            sub_str_tab[#sub_str_tab + 1] = str;
            break;
        end
        local sub_str = string.sub(str, 1, pos - 1);
        sub_str_tab[#sub_str_tab + 1] = sub_str;
        str = string.sub(str, pos + 1, #str);
    end

    return sub_str_tab;
end
function split(s, delim)
    assert (type (delim) == "string" and string.len (delim) > 0, "bad delimiter")
    local start = 1
    local t = {}  -- results table
    -- find each instance of a string followed by the delimiter
    while true do
        local pos = string.find (s, delim, start, true) -- plain find

        if not pos then
            break
        end

        table.insert (t, string.sub (s, start, pos - 1))
        start = pos + string.len (delim)
    end -- while
    -- insert final one (after last delimiter)
    table.insert (t, string.sub (s, start))
    return t
end -- function split

local function server()
    local host
    host = socket.udp(function(str, from)
        local s = split(str,"$")
        local sf = string.format("%10s|%10s|%10s",s[3],color(s[4]),s[5])  
        skynet.error(sf)
    end , "0.0.0.0", 8889)-- bind an address
end


skynet.start(function()
    skynet.newservice("debug_console",8000)
    local port = skynet.getenv("port") or 8889
    skynet.error("Listen UDP 0.0.0.0:"..port)
    skynet.fork(server)
end)
