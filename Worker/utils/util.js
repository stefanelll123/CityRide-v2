function replaceMocks(initialString, obj) {
    Object.keys(obj).forEach(key => {
        initialString = initialString.replace(`{${key}}`, obj[key]);
    });

    return initialString;
}

exports.sendEmail = async (env, message) => {
    try {
        const transformObject = { 
            date: new Date().toLocaleDateString(), 
            totals: message.total || '$',
            name: message.fullName || 'Dear Client'
        };
        const htmlString = replaceMocks(env.emailTemplate, transformObject);
        const mailOptions = {
            to: message.email || process.env.EMAIL_USER,
            subject: 'Your totals at City Ride',
            text: '',
            html: htmlString
        };
        
        const {response} = await env.transporter.sendMailPromisified(mailOptions);
        console.log(`Email sent: ${response}`);
    } catch (err) {
        console.error(err);
    }
};