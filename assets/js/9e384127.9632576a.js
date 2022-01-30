"use strict";(self.webpackChunkale_docs=self.webpackChunkale_docs||[]).push([[480],{3905:function(e,t,n){n.d(t,{Zo:function(){return c},kt:function(){return u}});var r=n(7294);function i(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function a(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function o(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?a(Object(n),!0).forEach((function(t){i(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):a(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function l(e,t){if(null==e)return{};var n,r,i=function(e,t){if(null==e)return{};var n,r,i={},a=Object.keys(e);for(r=0;r<a.length;r++)n=a[r],t.indexOf(n)>=0||(i[n]=e[n]);return i}(e,t);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);for(r=0;r<a.length;r++)n=a[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(i[n]=e[n])}return i}var s=r.createContext({}),p=function(e){var t=r.useContext(s),n=t;return e&&(n="function"==typeof e?e(t):o(o({},t),e)),n},c=function(e){var t=p(e.components);return r.createElement(s.Provider,{value:t},e.children)},d={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},m=r.forwardRef((function(e,t){var n=e.components,i=e.mdxType,a=e.originalType,s=e.parentName,c=l(e,["components","mdxType","originalType","parentName"]),m=p(n),u=i,y=m["".concat(s,".").concat(u)]||m[u]||d[u]||a;return n?r.createElement(y,o(o({ref:t},c),{},{components:n})):r.createElement(y,o({ref:t},c))}));function u(e,t){var n=arguments,i=t&&t.mdxType;if("string"==typeof e||i){var a=n.length,o=new Array(a);o[0]=m;var l={};for(var s in t)hasOwnProperty.call(t,s)&&(l[s]=t[s]);l.originalType=e,l.mdxType="string"==typeof e?e:i,o[1]=l;for(var p=2;p<a;p++)o[p]=n[p];return r.createElement.apply(null,o)}return r.createElement.apply(null,n)}m.displayName="MDXCreateElement"},342:function(e,t,n){n.r(t),n.d(t,{frontMatter:function(){return l},contentTitle:function(){return s},metadata:function(){return p},toc:function(){return c},default:function(){return m}});var r=n(7462),i=n(3366),a=(n(7294),n(3905)),o=["components"],l={sidebar_position:3},s="Unity Primitives",p={unversionedId:"serialization/unity-primitives",id:"serialization/unity-primitives",title:"Unity Primitives",description:"The most common Unity primitives can be used and serialized by the serializer. These types include",source:"@site/docs/serialization/unity-primitives.md",sourceDirName:"serialization",slug:"/serialization/unity-primitives",permalink:"/advanced-level-editor/docs/serialization/unity-primitives",editUrl:"https://github.com/hertzole/advanced-level-editor/tree/master/docs/docs/serialization/unity-primitives.md",tags:[],version:"current",sidebarPosition:3,frontMatter:{sidebar_position:3},sidebar:"tutorialSidebar",previous:{title:"C# Primitives",permalink:"/advanced-level-editor/docs/serialization/c-primitives"},next:{title:"Custom Types",permalink:"/advanced-level-editor/docs/serialization/custom-types"}},c=[],d={toc:c};function m(e){var t=e.components,n=(0,i.Z)(e,o);return(0,a.kt)("wrapper",(0,r.Z)({},d,n,{components:t,mdxType:"MDXLayout"}),(0,a.kt)("h1",{id:"unity-primitives"},"Unity Primitives"),(0,a.kt)("p",null,"The most common Unity primitives can be used and serialized by the serializer. These types include\n",(0,a.kt)("inlineCode",{parentName:"p"},"Bounds"),", ",(0,a.kt)("inlineCode",{parentName:"p"},"BoundsInt"),", ",(0,a.kt)("inlineCode",{parentName:"p"},"Color32"),", ",(0,a.kt)("inlineCode",{parentName:"p"},"Color"),", ",(0,a.kt)("inlineCode",{parentName:"p"},"GradientAlphaKey"),", ",(0,a.kt)("inlineCode",{parentName:"p"},"GradientColorKey"),", ",(0,a.kt)("inlineCode",{parentName:"p"},"Keyframe"),", ",(0,a.kt)("inlineCode",{parentName:"p"},"LayerMask"),", ",(0,a.kt)("inlineCode",{parentName:"p"},"Matrix4x4"),",\n",(0,a.kt)("inlineCode",{parentName:"p"},"Quaternion"),", ",(0,a.kt)("inlineCode",{parentName:"p"},"RangeInt"),", ",(0,a.kt)("inlineCode",{parentName:"p"},"Rect"),", ",(0,a.kt)("inlineCode",{parentName:"p"},"RectInt"),", ",(0,a.kt)("inlineCode",{parentName:"p"},"Vector2"),", ",(0,a.kt)("inlineCode",{parentName:"p"},"Vector2Int"),", ",(0,a.kt)("inlineCode",{parentName:"p"},"Vector3"),", ",(0,a.kt)("inlineCode",{parentName:"p"},"Vector3Int"),", ",(0,a.kt)("inlineCode",{parentName:"p"},"Vector4"),", and ",(0,a.kt)("inlineCode",{parentName:"p"},"WrapMode"),"."),(0,a.kt)("p",null,"You can also serialize references to other scene objects that has been spawned by the level editor. You just make a reference\nlike normal using GameObject, Transform, or your own scripts."),(0,a.kt)("p",null,"It also supports all these types as an array (for example ",(0,a.kt)("inlineCode",{parentName:"p"},"Color[]"),"), as lists (for example ",(0,a.kt)("inlineCode",{parentName:"p"},"List<Color>"),"), and as nullable\n(for example ",(0,a.kt)("inlineCode",{parentName:"p"},"Color?"),")."),(0,a.kt)("div",{className:"admonition admonition-tip alert alert--success"},(0,a.kt)("div",{parentName:"div",className:"admonition-heading"},(0,a.kt)("h5",{parentName:"div"},(0,a.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,a.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"12",height:"16",viewBox:"0 0 12 16"},(0,a.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.5 0C3.48 0 1 2.19 1 5c0 .92.55 2.25 1 3 1.34 2.25 1.78 2.78 2 4v1h5v-1c.22-1.22.66-1.75 2-4 .45-.75 1-2.08 1-3 0-2.81-2.48-5-5.5-5zm3.64 7.48c-.25.44-.47.8-.67 1.11-.86 1.41-1.25 2.06-1.45 3.23-.02.05-.02.11-.02.17H5c0-.06 0-.13-.02-.17-.2-1.17-.59-1.83-1.45-3.23-.2-.31-.42-.67-.67-1.11C2.44 6.78 2 5.65 2 5c0-2.2 2.02-4 4.5-4 1.22 0 2.36.42 3.22 1.19C10.55 2.94 11 3.94 11 5c0 .66-.44 1.78-.86 2.48zM4 14h5c-.23 1.14-1.3 2-2.5 2s-2.27-.86-2.5-2z"}))),"Fully Tested")),(0,a.kt)("div",{parentName:"div",className:"admonition-content"},(0,a.kt)("p",{parentName:"div"},"All the types above are covered by serialization tests! They are completely safe to use without any surprise issues."))))}m.isMDXComponent=!0}}]);