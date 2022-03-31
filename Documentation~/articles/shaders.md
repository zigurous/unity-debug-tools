---
slug: "/manual/shaders"
---

# Debug Shaders

The **Debug Tools** package comes with several shaders to visualize different vertex data. These shaders are located under `Zigurous > Debug` within the shader selection menu.

<hr/>

## UV

```
v2f vert (appdata v)
{
    v2f o;
    o.pos = UnityObjectToClipPos(v.vertex);
    o.uv = float4(v.texcoord.xy, 0, 0);
    return o;
}
```

![](https://docs.unity3d.com/uploads/Main/SL-DebugUV1.png)

<hr/>

## Normals

```
v2f vert (appdata v)
{
    v2f o;
    o.pos = UnityObjectToClipPos(v.vertex);
    o.color.xyz = v.normal * 0.5 + 0.5;
    o.color.w = 1.0;
    return o;
}
```

![](https://docs.unity3d.com/uploads/Main/SL-DebugNormals.png)

<hr/>

## Tangents

```
v2f vert (appdata v)
{
    v2f o;
    o.pos = UnityObjectToClipPos(v.vertex);
    o.color = v.tangent * 0.5 + 0.5;
    return o;
}
```

![](https://docs.unity3d.com/uploads/Main/SL-DebugTangents.png)

<hr/>

## Bitangents

```
v2f vert (appdata v)
{
    v2f o;
    o.pos = UnityObjectToClipPos(v.vertex);
    float3 bitangent = cross(v.normal, v.tangent.xyz) * v.tangent.w;
    o.color.xyz = bitangent * 0.5 + 0.5;
    o.color.w = 1.0;
    return o;
}
```

![](https://docs.unity3d.com/uploads/Main/SL-DebugBinormals.png)

<hr/>

## Vertex Color

```
v2f vert (appdata v)
{
    v2f o;
    o.pos = UnityObjectToClipPos(v.vertex);
    o.color = v.color;
    return o;
}
```

![](https://docs.unity3d.com/uploads/Main/SL-DebugColors.png)
