<template>
  <showcase-create ref="form" v-bind="createData" @onSend="createAgent($event)"/>
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import {
  required,
  maxLength,
  minLength,
  numeric,
  email,
  phone
} from '@/utils/validation/i18n-validators'
import { useToast } from 'vue-toastification'

export default {
  name: 'AgentCreate',
  components: {
    ShowcaseCreate
  },
  setup () {
    const toast = useToast()
    return { toast }
  },
  data: () => {
    return {
      createData: {
        title: 'Создать контрагента',
        fields: [
          {
            label: 'Тип',
            placeholder: 'Тип контрагента',
            type: 'select',
            modelValue: 'agentTypeId',
            validation: { required },
            values: []
          },
          {
            label: 'Адрес',
            placeholder: 'Адрес',
            type: 'select',
            modelValue: 'addressId',
            validation: { required },
            values: []
          },
          {
            label: 'Наименование',
            placeholder: 'Наименование',
            modelValue: 'organizationName',
            cols: ['col-md-4'],
            validation: { required }
          },
          {
            label: 'Расчетный счет',
            placeholder: 'Расчетный счет',
            modelValue: 'checkingAccount',
            validation: {
              required,
              numeric,
              minLength: minLength(20),
              maxLength: maxLength(20)
            },
            cols: ['col-md-4']
          },
          {
            label: 'ИНН',
            placeholder: 'ИНН',
            modelValue: 'individualTaxpayerNumber',
            validation: {
              required,
              numeric,
              minLength: minLength(10),
              maxLength: maxLength(12)
            },
            cols: ['col-md-4']
          },
          {
            label: 'Телефон',
            placeholder: 'Телефон',
            modelValue: 'phone',
            type: 'tel',
            validation: { required, phone }
          },
          {
            label: 'Электронная почта',
            placeholder: 'Электронная почта',
            modelValue: 'email',
            type: 'email',
            validation: { required, email }
          }
        ]
      }
    }
  },
  methods: {
    createAgent (data) {
      this.$api.agent.createAgent(data)
        .then(() => {
          this.toast.success('Контрагент успешно создан')
          this.$refs.form.clearForm()
        })
        .catch(() => {
          this.toast.error('Ошибка при создании контрагента, повторите позже')
        })
    }
  },
  created () {
    this.$api.agent.getAgentTypes()
      .then(data => {
        this.createData.fields.find(item => item.modelValue === 'agentTypeId').values = data.map(item => {
          return Object.assign({}, { text: item.name, value: item.id })
        })
      })

    this.$api.address.getAddressForUsing()
      .then((data) => {
        this.createData.fields.find(item => item.modelValue === 'addressId').values = data.map(item => {
          return Object.assign({}, {
            text: `${item.index}, ${item.subject}, ${item.location}, ${item.street ?? '-'}, ${item.house ?? ''}`,
            value: item.id
          })
        })
      })
  }
}
</script>
