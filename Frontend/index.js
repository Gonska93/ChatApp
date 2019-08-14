// Import the library
const server = require('server');

server(ctx => 'Hello world').then(ctx => {
  console.log(`Server launched on http://localhost:${ctx.options.port}/`);
});