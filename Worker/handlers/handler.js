const {sendEmail} = require('../utils/util');

module.exports = (env) => {
    env.channel.consume(process.env.QUEUE || 'email_queue', async (payload) => {
        try {
            const payloadContent = JSON.parse(payload.content);
            const {message} = payloadContent;

            sendEmail(env, message);         
        } catch (err) {
            console.error(err);
        }
    },
    {noAck: true});
};