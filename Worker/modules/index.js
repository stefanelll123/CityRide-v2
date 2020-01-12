const amqplib = require('amqplib');
const fs = require('fs');
const nodemailer = require('nodemailer');
const util = require('util');

async function initRabbit(env) {
    try {
        const connection = await amqplib.connect(process.env.AMQP_URL);
        const channel = await connection.createChannel();
        await channel.assertQueue(process.env.QUEUE || 'tasks');

        env['channel'] = channel;
    } catch (err) {
        throw err;
    }
}

function getEmailTemplate(env) {
    try {
        env['emailTemplate'] = fs.readFileSync('./email_structure/index.html', 'utf8');
    } catch (err) {
        throw err;
    }
}

function initTransporter(env) {
    const transporter = nodemailer.createTransport({
        service: process.env.SERVICE,
        auth: {
            user: process.env.EMAIL_USER,
            pass: process.env.EMAIL_PASSWORD
        }
    });

    transporter.sendMailPromisified = util.promisify(transporter.sendMail);
    env['transporter'] = transporter;
}

async function initModules(env) {
    await initRabbit(env);
    getEmailTemplate(env);
    initTransporter(env);
}

exports.initModules = initModules;