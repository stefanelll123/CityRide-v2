(async () => {
    try {
        const http = require('http');
        const {initModules} = require('./modules/index');
        const handler = require('./handlers/handler');
        const env = {};
        
        require('dotenv').config()
        
        await initModules(env);
    
        const server = http.createServer();
        server.listen(process.env.PORT || 3000, () => {
            console.log('Worker started!');
    
            handler(env);
        });
    } catch (err) {
        console.error(err);
        process.exit(0);
    }
})();