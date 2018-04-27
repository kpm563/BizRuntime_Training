/**
 * @module ol/render/webgl/polygonreplay/defaultshader
 */
// This file is automatically generated, do not edit.
// Run `make shaders` to generate, and commit the result.

import {DEBUG_WEBGL} from '../../../index.js';
import WebGLFragment from '../../../webgl/Fragment.js';
import WebGLVertex from '../../../webgl/Vertex.js';

export const fragment = new WebGLFragment(DEBUG_WEBGL ?
  'precision mediump float;\n\n\n\nuniform vec4 u_color;\nuniform float u_opacity;\n\nvoid main(void) {\n  gl_FragColor = u_color;\n  float alpha = u_color.a * u_opacity;\n  if (alpha == 0.0) {\n    discard;\n  }\n  gl_FragColor.a = alpha;\n}\n' :
  'precision mediump float;uniform vec4 e;uniform float f;void main(void){gl_FragColor=e;float alpha=e.a*f;if(alpha==0.0){discard;}gl_FragColor.a=alpha;}');

export const vertex = new WebGLVertex(DEBUG_WEBGL ?
  '\n\nattribute vec2 a_position;\n\nuniform mat4 u_projectionMatrix;\nuniform mat4 u_offsetScaleMatrix;\nuniform mat4 u_offsetRotateMatrix;\n\nvoid main(void) {\n  gl_Position = u_projectionMatrix * vec4(a_position, 0.0, 1.0);\n}\n\n\n' :
  'attribute vec2 a;uniform mat4 b;uniform mat4 c;uniform mat4 d;void main(void){gl_Position=b*vec4(a,0.0,1.0);}');
