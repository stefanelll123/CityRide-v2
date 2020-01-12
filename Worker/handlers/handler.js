const {sendEmail} = require('../utils/util');

module.exports = (env) => {
    env.channel.consume(process.env.QUEUE || 'tasks', async (message) => {
        try {
            const msg = JSON.parse(message.content);

            sendEmail(env, msg);         
        } catch (err) {
            console.error(err);
        }
    },
    {noAck: true});
};